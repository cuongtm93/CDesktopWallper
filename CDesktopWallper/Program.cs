using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDesktopWallper.Frontend;
using FluentScheduler;
using Microsoft.Owin.Hosting;
using Ninject;
namespace CDesktopWallper
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{B594DA2D-9290-4702-BD07-673AD184A06D}");
        [STAThread]
        static void Main()
        {
            // Browser Console Setup
            new BrowserConsoleWriter();

            if (!mutex.WaitOne(TimeSpan.Zero, true))
                return;

            

            Application.ApplicationExit += OnApplicationExit;
            Application.Idle += Application_Idle;
            OnApplicationStart();
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            GC.Collect();
        }

        static void OnApplicationStart()
        {
            try
            {
                var setting = Kernel.Resolve<ISetting>();
                setting.Load();

                //new HookingManager().Start();

                IWsServer ws = Kernel.Resolve<IWsServer>();
                ws.Start();


                string baseUri = "http://*:8080/";
                WebApp.Start<Startup>(baseUri);

                

                Wait();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi : " + e.Message);
                Application.Exit();
            }
            
           
            
        }
        private static void Wait()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(100000);
            }
        }
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            Kernel.Resolve<ISetting>().Save();
        }
    }
}
