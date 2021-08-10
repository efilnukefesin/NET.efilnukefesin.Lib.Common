using NET.efilnukefesin.Lib.Common.Interfaces;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class ObjectService : IObjectService, IInitialize
    {
        #region Properties

        public bool IsInitialized { get; private set; } = false;

        private ILogService logService;

        private Dictionary<IBaseObject, Type> items;

        #endregion Properties

        #region Construction

        public ObjectService(ILogService LogService)
        {
            this.logService = LogService;
        }

        #endregion Construction

        #region Methods

        #region Initialize
        public void Initialize()
        {
            if (!this.IsInitialized)
            {
                this.items = new Dictionary<IBaseObject, Type>();
                this.IsInitialized = true;
            }
        }
        #endregion Initialize

        #region Create
        public T Create<T>(params object[] Parameters) where T : class, IBaseObject
        {
            T result = default;
            this.logService.Info("ObjectService", "Create", $"Attempting to create an object of type '{typeof(T)}'");
            try
            {
                result = DiContainer.Resolve<T>(Parameters);
                this.logService.Info("ObjectService", "Create", $"Successfully created the object");
                this.items.Add(result, typeof(T));
            }
            catch (Exception ex)
            {
                this.logService.Error("ObjectService", "Create", $"Failed when creating the object", ex);
            }
            return result;
        }
        #endregion Create

        #region Count
        public int Count()
        {
            int result = -1;

            if (this.IsInitialized)
            {
                result = this.items.Count;
            }

            return result;
        }
        #endregion Count

        #endregion Methods

        #region Events

        #endregion Events
    }
}
