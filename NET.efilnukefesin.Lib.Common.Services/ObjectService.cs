using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class ObjectService : IObjectService
    {
        #region Properties

        private ILogService logService;

        #endregion Properties

        #region Construction

        public ObjectService(ILogService LogService)
        {
            this.logService = LogService;
        }

        #endregion Construction

        #region Methods

        #region Create
        public T Create<T>(params object[] Parameters) where T : class, IBaseObject
        {
            T result = default;
            this.logService.Info("ObjectService", "Create", $"Attempting to create an object of type '{typeof(T)}'");
            try
            {
                result = DiContainer.Resolve<T>(Parameters);
                this.logService.Info("ObjectService", "Create", $"Successfully created the object");
            }
            catch (Exception ex)
            {
                this.logService.Error("ObjectService", "Create", $"Failed when creating the object", ex);
            }
            return result;
        }
        #endregion Create

        #endregion Methods

        #region Events

        #endregion Events
    }
}
