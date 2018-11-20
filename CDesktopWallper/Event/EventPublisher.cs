using System;
using System.Linq;
using System.Collections.Generic;
using Ninject;
namespace CDesktopWallper
{
    /// <summary>
    /// Event publisher
    /// </summary>
    public class EventPublisher : IEventPublisher
    {
        #region Fields

        private readonly ISubscriptionService _subscriptionService;

        private static readonly log4net.ILog _log = 
                log4net.LogManager.
                GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Ctor

        public EventPublisher()
        {
            this._subscriptionService = Kernel.Resolve<ISubscriptionService>();
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Publish to consumer
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="x">Event consumer</param>
        /// <param name="eventMessage">Event message</param>
        protected virtual void PublishToConsumer<T>(IConsumer<T> x, T eventMessage)
        {
            try
            {
                x.HandleEvent(eventMessage);
            }
            catch (Exception exc)
            {
                try
                {
                        _log.Error(exc.Message, exc);
                }
                catch (Exception)
                {
                    //do nothing
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Publish event
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="eventMessage">Event message</param>
        public virtual void Publish<T>(T eventMessage)
        {
            //get all event subscribers, excluding from not installed plugins
            var subscribers = this._subscriptionService.GetSubscriptions<T>().ToList();
            //    .Where(subscriber => PluginManager.FindPlugin(subscriber.GetType())?.Installed ?? true).ToList();

            //publish event to subscribers

            subscribers.ForEach(subscriber => PublishToConsumer(subscriber, eventMessage));

            //foreach (var sub in subscribers)
            //{
            //    PublishToConsumer(sub, eventMessage);
            //}
        }

        #endregion
    }
}