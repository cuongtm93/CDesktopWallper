using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDesktopWallper
{
    public class AdvertisementDisplayTask : IJob
    {
        [DllImport("user32.dll", SetLastError = true)]

        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]

        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]

        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]

        static extern bool RedrawWindow(IntPtr hWnd, [In] ref RECT lprcUpdate,

          IntPtr hrgnUpdate, uint flags);

        [DllImport("user32.dll")]

        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);



        const int RDW_NOERASE = 0x0020;

        const int RDW_UPDATENOW = 0x0100;

        const int RDW_INVALIDATE = 0x0001;



        RECT rect;


        public class RECT //A class for Win32 RECT.

        {

            public int left;

            public int top;

            public int right;

            public int bottom;

            public RECT()

            {

            }

            public RECT(int left, int top, int right, int bottom)

            {

                this.left = left;

                this.top = top;

                this.right = right;

                this.bottom = bottom;

            }

        }
        public void Execute()
        {
            this.rect = new RECT(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);



            IntPtr ProgMan = FindWindow("Progman", "Program Manager");

            IntPtr Shell = FindWindowEx(ProgMan, IntPtr.Zero, "SHELLDLL_DefView", null);

            IntPtr listView = FindWindowEx(Shell, IntPtr.Zero, "SysListView32", "FolderView"); //We get the handler here

            IntPtr hdc = GetDC(listView);

            if (hdc != IntPtr.Zero)

            {

                var g = Graphics.FromHdc(hdc);
                var _ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                var _ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                var img = Image.FromFile("D:\\Untitled.png");
                g.DrawImage(img, new PointF((int)(_ScreenWidth * 0.75), 200));
                g.Dispose();
                img.Dispose();
            }

            else

            {

                MessageBox.Show("Cannot get hdc");

            }

            bool result = RedrawWindow(listView, ref this.rect, IntPtr.Zero, RDW_NOERASE | RDW_INVALIDATE | RDW_UPDATENOW); //Redraw the icons

            ReleaseDC(listView, hdc); //Don't forget to release the HDC after you use it.
        }
    }
}
