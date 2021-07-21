using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Linq;
using NET.efilnukefesin.Lib.Common.Services.Objects;
using NET.efilnukefesin.Lib.Common.Extensions;
using NET.efilnukefesin.Lib.Common.Windows.Services.Classes;
using NET.efilnukefesin.Lib.Common.Windows.Services.Helpers;

namespace NET.efilnukefesin.Lib.Common.Windows.Services
{
    public class WindowsTechnicalService : ITechnicalService
    {
        #region Properties

        public bool IsInitialized { get; private set; } = false;

        public string OperatingSystemName { get; private set; }
        public string ComputerName { get; private set; }

        public IList<IMonitor> Monitors { get; private set; }

        #endregion Properties

        #region Construction

        #endregion Construction

        #region Methods

        #region Initialize
        public void Initialize()
        {
            if (!this.IsInitialized)
            {
                this.OperatingSystemName = this.GetOsName();
                this.ComputerName = this.GetComputerName();
                this.Monitors = this.GetMonitors();

                this.IsInitialized = true;
            }
        }
        #endregion Initialize

        #region GetOsName
        private string GetOsName()
        {
            string result = "";
            result = this.GetWin32_OperatingSystemInfo("Caption");
            return result;
        }
        #endregion GetOsName

        #region GetComputerName
        private string GetComputerName()
        {
            string result = "";
            result = this.GetWin32_OperatingSystemInfo("csname");
            return result;
        }
        #endregion GetComputerName

        #region GetWin32_OperatingSystemInfo
        private string GetWin32_OperatingSystemInfo(string PropertyName)
        {
            string result = "";
            var name = (from x in new ManagementObjectSearcher($"SELECT {PropertyName} FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue(PropertyName)).FirstOrDefault();
            result = name != null ? name.ToString() : "Unknown";

            return result;
        }
        #endregion GetWin32_OperatingSystemInfo

        #region GetMonitors
        private IList<IMonitor> GetMonitors()
        {
            IList<IMonitor> result = new List<IMonitor>();

            // get all monitors
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM WmiMonitorID");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string userFriendlyName = ((ushort[])queryObj["UserFriendlyName"]).ConvertToText();
                    string manufacturerName = ((ushort[])queryObj["ManufacturerName"]).ConvertToText();
                    IMonitor monitor = DiContainer.Resolve<Monitor>($"{manufacturerName} {userFriendlyName}", (string)queryObj["InstanceName"], false);
                    result.Add(monitor);
                }
            }
            catch (ManagementException e)
            {
                //TODO: add user signalling or logging
            }

            // get Primary one
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DesktopMonitor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string pnpDeviceId = (string)queryObj["PNPDeviceID"];
                    pnpDeviceId.Replace("\\", "\\\\");
                    IMonitor monitor = result.Where(x => x.PnPDeviceID.ToUpperInvariant().Contains(pnpDeviceId.ToUpperInvariant())).FirstOrDefault();
                    if (monitor != null)
                    {
                        monitor.SetPrimary();
                    }
                }
            }
            catch (ManagementException e)
            {
                //TODO: add user signalling or logging
            }

            var _monitorInfos = new List<MonitorInfoWithHandle>();

            // Enumerate monitors
            MonitorHelper.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorHelper.MonitorEnum, IntPtr.Zero);

            var x = MonitorHelper.GetHandles();

            return result;
        }
        #endregion GetMonitors

        #endregion Methods
    }
}
