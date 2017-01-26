using PclSystemInfo.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PclSystemInfo.Modules
{
    public class Processor : AProcessor
    {
        private const string WmiComponentName = "Win32_Processor";

        public Processor()
        {
        }

        public override string ProcessorName
        {
            get
            {
                string output = String.Empty;
                switch (MachineEnvironment.Environment.OS.PlatformId)
                {
                    // Should always break early...
                    case PclPlatformId.None:
                        break;
                    // TODO : /proc/cpuinfo
                    case PclPlatformId.MaxOSX:
                    case PclPlatformId.Unix:
                        break;
                    // TODO
                    case PclPlatformId.Xbox:
                        break;
                    // Can use WMI system...
                    case PclPlatformId.Win32NT:
                    case PclPlatformId.Win32S:
                    case PclPlatformId.Win32Windows:
                    case PclPlatformId.WinCE:
                        var result = WMI.GetWmiComponentKeyValue(WmiComponentName, "Name");
                        if (result.Key != null)
                            output = result.Value;
                        break;
                }

                return output;
            }
        }
    }
}
