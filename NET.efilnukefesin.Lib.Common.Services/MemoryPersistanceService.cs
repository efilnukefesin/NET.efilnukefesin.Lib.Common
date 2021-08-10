using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class MemoryPersistanceService : IPersistanceService
    {
        #region Properties

        public bool IsInitialized { get; private set; } = false;

        private Dictionary<string, string> endpoints;
        private Dictionary<string, object> values;

        #endregion Properties

        #region Construction

        public MemoryPersistanceService()
        { 
        
        }

        #endregion Construction

        #region Methods

        #region Initialize
        public void Initialize()
        {
            if (!this.IsInitialized)
            {
                this.endpoints = new Dictionary<string, string>();
                this.values = new Dictionary<string, object>();
            }
        }
        #endregion Initialize

        #region AddEndpoint
        public bool AddEndpoint(string EndPoint, string Path)
        {
            bool result = false;
            if (!this.Exists(EndPoint))
            {
                this.endpoints.Add(EndPoint, Path);
                result = true;
            }
            return result;
        }
        #endregion AddEndpoint

        #region Write
        public void Write<T>(string EndPoint, T Value)
        {
            if (this.Exists(EndPoint))
            {
                string path = this.GetPath(EndPoint);
                if (this.values.ContainsKey(path))
                {
                    // delete if exists
                    this.values.Remove(path);
                }
                this.values.Add(path, Value);
            }
        }
        #endregion Write

        #region Read
        public T Read<T>(string EndPoint)
        {
            T result = default;

            if (this.Exists(EndPoint))
            {
                string path = this.GetPath(EndPoint);
                if (this.values.ContainsKey(path))
                {
                    result = (T)this.values[path];
                }
            }

            return result;
        }
        #endregion Read

        #region ValueExists
        public bool ValueExists(string EndPoint)
        {
            bool result = false;

            if (this.Exists(EndPoint))
            {
                result = this.values.ContainsKey(this.GetPath(EndPoint));
            }

            return result;
        }
        #endregion ValueExists

        #region Exists
        public bool Exists(string EndPoint)
        {
            bool result = false;

            if (this.endpoints.ContainsKey(EndPoint))
            {
                result = true;
            }

            return result;
        }
        #endregion Exists

        #region GetPath
        private string GetPath(string Endpoint)
        {
            string result = default;

            if (this.Exists(Endpoint))
            {
                result = this.endpoints[Endpoint];
            }

            return result;
        }
        #endregion GetPath

        #endregion Methods
    }
}
