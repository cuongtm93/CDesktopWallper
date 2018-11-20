using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CDesktopWallper;
using Newtonsoft.Json;
using Ninject;
using CDesktopWallper.Extensions;
using FluentScheduler;
using System.IO;

namespace CDesktopWallper
{
    class DesktopWallperRandommizeTask : IJob
    {
        private readonly IDesktop _desktop;
        private readonly Random _random;
        private readonly ISetting _setting;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _text;

        private IWallperSource wallperSources;
        private string currentWallperPath = string.Empty;
        public DesktopWallperRandommizeTask()
        {
            this._setting = Kernel.Resolve<ISetting>();
            this._eventPublisher = Kernel.Resolve<IEventPublisher>();
            this._text = Kernel.Resolve<ILocalizationService>();
            this._desktop = Kernel.Resolve<IDesktop>();
            this._random = new Random();
        }

        /// <summary>
        ///  Bỏ hàm này
        /// </summary>
        /// <param name="eventMessage"></param>
        public void HandleEvent(WallperSourceChangedEvent eventMessage)
        {
            var _wallpers = new List<WallperDescription>();

            Task.Run(() =>
            {
                string source = this._setting.Data.WallerSource;
                this.wallperSources = Kernel.Resolve<IWallperSource>(source);
                _wallpers = this.wallperSources.GetWallpers();
            }).GetAwaiter().OnCompleted(() =>
            {
                //this.eventPublisher.Publish(new WallperSourceLoadCompletedEvent(source, _wallpers));
                string source = this._setting.Data.WallerSource;
                this._setting.Data.Wallpers.AddRange(_wallpers);
                this._setting.Data.Wallpers = this._setting.Data.Wallpers.Distinct().ToList();
                this._setting.Save();
                MessageBox.Show($"Tải xong nguồn url from {source}");
            });
        }

        public void Execute()
        {
            List<WallperDescription> _wallpers = new List<WallperDescription>();
            WallperDescription randomWallper = default;

            if (this._setting.Data.WallerSource == nameof(InternetWallperSource))
            {
                _wallpers = this._setting.Data.Wallpers;
                if (!_wallpers.Any())
                    return;
            }
            else
            {
                _wallpers = Kernel.Resolve<IWallperSource>(nameof(LocalWallperSource)).GetWallpers();
                var randomInteger = this._random.Next(_wallpers.Count());
                randomWallper = _wallpers.ElementAt(randomInteger);
                if (randomWallper.Url == this.currentWallperPath)
                    return;
            }

            Task.Run(() =>
            {
                this._desktop.SetWallper(randomWallper, WallperStyle.Centered);
                this.currentWallperPath = randomWallper.Url;
            });

        }
    }
}
