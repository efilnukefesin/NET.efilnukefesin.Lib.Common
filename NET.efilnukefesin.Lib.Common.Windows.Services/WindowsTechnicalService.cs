using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Linq;
using NET.efilnukefesin.Lib.Common.Services.Objects;

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

        private string GetWin32_OperatingSystemInfo(string PropertyName)
        {
            string result = "";
            var name = (from x in new ManagementObjectSearcher($"SELECT {PropertyName} FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue(PropertyName)).FirstOrDefault();
            result = name != null ? name.ToString() : "Unknown";

            return result;
        }

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

        //#region GetMonitors
        //private IList<IMonitor> GetMonitors()
        //{
        //    IList<IMonitor> result = new List<IMonitor>();

        //    try
        //    {
        //        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DisplayControllerConfiguration");

        //        foreach (ManagementObject queryObj in searcher.Get())
        //        {
        //            Console.WriteLine("-----------------------------------");
        //            Console.WriteLine("Win32_DisplayControllerConfiguration instance");
        //            Console.WriteLine("-----------------------------------");
        //            Console.WriteLine("VerticalResolution: {0}", queryObj["VerticalResolution"]);
        //        }

        //        // https://stackoverflow.com/questions/1528266/list-of-valid-resolutions-for-a-given-screen
        //    }
        //    catch (ManagementException e)
        //    {
        //        //MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
        //    }

        //    return result;
        //}
        //#endregion GetMonitors

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
                    IMonitor monitor = DiContainer.Resolve<Monitor>("Some Name", (string)queryObj["InstanceName"], false, new List<IResolution>());
                    result.Add(monitor);
                }
            }
            catch (ManagementException e)
            {
                //MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
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
                //MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }

            try
            {
                SelectQuery query = new SelectQuery("Win32_VideoController");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                List<string> properties = new List<string>();
                Dictionary<string, object> propertiesAndValues = new Dictionary<string, object>();

                foreach (ManagementBaseObject envVar in searcher.Get())
                {
                    //Console.WriteLine(envVar["VideoModeDescription"]);
                    //Console.WriteLine(envVar["AdapterRAM"]);
                    foreach (PropertyData obj in envVar.Properties)
                    {
                        string name = obj.Name;
                        object value = envVar[name];
                        properties.Add(name);
                        propertiesAndValues.Add(name, value);
                    }
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
