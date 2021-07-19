using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Linq;

namespace NET.efilnukefesin.Lib.Common.Windows.Services
{
    public class WindowsTechnicalService : ITechnicalService
    {
        #region Properties

        public bool IsInitialized { get; private set; } = false;

        public string OperatingSystemName { get; private set; }

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
                this.Monitors = this.GetMonitors();

                this.IsInitialized = true;
            }
        }
        #endregion Initialize

        #region GetOsName
        private string GetOsName()
        {
            string result = "";
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            result = name != null ? name.ToString() : "Unknown";

            return result;
        }
        #endregion GetOsName

        //#region GetMonitors
        //private IList<IMonitor> GetMonitors()
        //{
        //    IList<IMonitor> result = new List<IMonitor>();

        //    ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\root\wmi", @"SELECT * FROM WmiMonitorBasicDisplayParams");

        //    //Calculate and output size for each monitor
        //    foreach (ManagementObject managementObject in searcher.Get())
        //    {
        //        //Calculate monitor size in inches
        //        double width = (byte)managementObject["MaxHorizontalImageSize"] / 2.54;
        //        double height = (byte)managementObject["MaxVerticalImageSize"] / 2.54;
        //        double diagonal = Math.Sqrt(width * width + height * height);

        //        //Output monitor size
        //        Console.WriteLine("Monitor Size: {0:F1}\"", diagonal);
        //    }

        //    return result;
        //}
        //#endregion GetMonitors

        #region GetMonitors
        private IList<IMonitor> GetMonitors()
        {
            IList<IMonitor> result = new List<IMonitor>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DisplayControllerConfiguration");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_DisplayControllerConfiguration instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("VerticalResolution: {0}", queryObj["VerticalResolution"]);
                }
            }
            catch (ManagementException e)
            {
                //MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }

            return result;
        }
        #endregion GetMonitors

        #endregion Methods
    }
}
