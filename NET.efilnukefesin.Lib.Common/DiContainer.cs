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
        public static T Resolve<T>(params object[] CtorParameters)
        {
            T result = default;

            if (DiContainer.serviceProvider != null)
            {
                bool isServiceRgistered = DiContainer.serviceProvider.GetService<T>() != null;

                if (isServiceRgistered)
                {
                    result = (T)DiContainer.serviceProvider.GetRequiredService<T>();
                }
                else  //TODO: make better if, currently we are assuming that the user wants to resolve a not-known class
                {
                    result = ActivatorUtilities.CreateInstance<T>(DiContainer.serviceProvider, CtorParameters);
                }
            }

            //TODO: if the result implements IInitialize then call it

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
