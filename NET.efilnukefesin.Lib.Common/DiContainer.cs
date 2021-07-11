using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NET.efilnukefesin.Lib.Common
{
    public static class DiContainer
    {
        #region Properties

        internal static IServiceProvider serviceProvider;

        #endregion Properties

        #region Methods

        #region Resolve
        public static T Resolve<T>()
        {
            T result = default;

            if (DiContainer.serviceProvider != null)
            {
                result = (T)DiContainer.serviceProvider.GetRequiredService<T>();
            }

            return result;
        }
        #endregion Resolve

        #region SetServiceProvider
        public static void SetServiceProvider(IServiceProvider ServiceProvider)
        {
            DiContainer.serviceProvider = ServiceProvider;
        }
        #endregion SetServiceProvider

        #endregion Methods
    }
}
