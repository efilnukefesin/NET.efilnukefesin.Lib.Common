using Microsoft.Extensions.DependencyInjection;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Services;
using NET.efilnukefesin.Lib.Common.Windows.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper
{
    internal static class TestBootStrapper
    {
        #region Properties

        #endregion Properties

        #region Methods

        #region Register

        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<ILogService, DebugLogService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddSingleton<IErrorService, DebugErrorService>();
            services.AddSingleton<ITimeService, TimeService>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<ITechnicalService, TechnicalService>();
            services.AddSingleton<IFeatureService, FeatureService>();
            services.AddTransient<IUserNotificationService, UserNotificationService>();
            services.AddSingleton<IPersistanceService, MemoryPersistanceService>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddSingleton<IObjectService, ObjectService>();
            services.AddSingleton<ITranslationService, TranslationService>();

            DiContainer.SetServiceProvider(services.BuildServiceProvider());  //TODO: move to a different class
        }
        #endregion Register

        #region RegisterForWindows

        public static void RegisterForWindows(IServiceCollection services)
        {
            services.AddSingleton<ILogService, DebugLogService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddSingleton<IErrorService, DebugErrorService>();
            services.AddSingleton<ITimeService, TimeService>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<ITechnicalService, WindowsTechnicalService>();
            services.AddSingleton<IFeatureService, FeatureService>();
            services.AddTransient<IUserNotificationService, UserNotificationService>();
            services.AddSingleton<IPersistanceService, MemoryPersistanceService>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddSingleton<IObjectService, ObjectService>();
            services.AddSingleton<ITranslationService, TranslationService>();

            DiContainer.SetServiceProvider(services.BuildServiceProvider());  //TODO: move to a different class
        }
        #endregion RegisterForWindows

        #endregion Methods
    }
}
