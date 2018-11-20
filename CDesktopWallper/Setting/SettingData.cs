using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDesktopWallper.Extensions;
using FluentScheduler;

namespace CDesktopWallper
{

    public class SettingData : IClientSettingData
    {

        private readonly IEventPublisher _eventPublisher;
        private readonly Registry taskRegistry;

        public SettingData()
        {
            this._eventPublisher = Kernel.Resolve<IEventPublisher>();
            this.taskRegistry = new Registry();
        }
        private string _WallerSource;

        public string WallerSource
        {
            get
            {
                return this._WallerSource;
            }
            set
            {
                if (this._WallerSource.IsChanged(value))
                    this._eventPublisher.Publish(new WallperSourceChangedEvent(value));

                this._WallerSource = value;
            }
        }


        public List<WallperDescription> Wallpers { get; set; }


        public List<string> UrlSubscriptions { get; set; }


        public List<string> Keywords { get; set; }

        private string _Locale;

        public string Locale
        {
            get
            {
                return this._Locale;
            }
            set
            {

                if (this._Locale.IsChanged(value))
                    this._eventPublisher.Publish(new LocaleChangedEvent(value));

                this._Locale = value;
            }
        }

        private bool _AutoWallper;
        public bool AutoWallper
        {
            get => _AutoWallper;
            set
            {
                _AutoWallper = value;
                if (_AutoWallper)
                {
                    taskRegistry.Schedule<DesktopWallperRandommizeTask>().
                        WithName(nameof(DesktopWallperRandommizeTask))
                    .ToRunNow().AndEvery(10).Seconds();
                    JobManager.Initialize(this.taskRegistry);
                }
                else
                {

                    var t = JobManager.GetSchedule(nameof(DesktopWallperRandommizeTask));
                    if (t != null)
                        t.Disable();
                }
            }
        }
    }
}
