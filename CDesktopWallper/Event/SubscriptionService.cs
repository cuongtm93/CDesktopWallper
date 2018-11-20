﻿using System.Collections.Generic;
using System.Linq;
using Ninject;
namespace CDesktopWallper
{
    /// <summary>
    /// Event subscription service
    /// </summary>
    public class SubscriptionService : ISubscriptionService
    {
        #region Methods

        /// <summary>
        /// Get subscriptions
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Event consumers</returns>
        public IList<IConsumer<T>> GetSubscriptions<T>()
        {
            return Kernel.ResolveAll<IConsumer<T>>().ToList();
        }

        #endregion
    }
}