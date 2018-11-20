using CDesktopWallper.Frontend;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CDesktopWallper.Extensions
{

    public static class WallperExtensions
    {
        private static readonly IEnumerable<IWallperFilter> _wallperFilters;
        private static readonly IWsServer wsServer;
        static WallperExtensions()
        {
            WallperExtensions._wallperFilters = Kernel.ResolveAll<IWallperFilter>();
            wsServer = Kernel.Resolve<IWsServer>();
        }
        public static bool IsNotValid(this WallperDescription wallper)
        {
            return WallperExtensions._wallperFilters.Any(filter => !filter.Next(wallper));
        }

        public static List<WallperDescription> GetInvalids(this List<WallperDescription> wallpers)
        {
            int maxConcurrency = 20;
            using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(maxConcurrency))
            {
                var invalids = new ConcurrentBag<WallperDescription>();
                List<Task> tasks = new List<Task>();
                foreach (var wallper in wallpers)
                {
                    concurrencySemaphore.Wait();

                    var t = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            wsServer.SendToPath("/InternetWallperWebViewWS", $"Checking {wallper.Url}");
                            if (wallper.IsNotValid())
                            {
                                wsServer.SendToPath("/InternetWallperWebViewWS", $"Not Valid");
                                invalids.Add(wallper);
                            }
                            else
                            {
                                wsServer.SendToPath("/InternetWallperWebViewWS", $"OK");

                            }

                        }
                        finally
                        {
                            concurrencySemaphore.Release();
                        }
                    });

                    tasks.Add(t);
                }
                Task.WaitAll(tasks.ToArray());
                return invalids.ToList();
            }

        }
    }
}

