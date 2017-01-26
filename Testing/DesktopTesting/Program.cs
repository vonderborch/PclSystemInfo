using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PclSystemInfo;

namespace DesktopTesting
{
    class Program
    {
        static void Main(string[] args)
        {


            var va = MachineEnvironment.Environment.CPU.ProcessorName;
            var va2 = MachineEnvironment.Environment.OS.VersionString;
            var va3 = MachineEnvironment.Environment.OS.PlatformId;
            var va4 = MachineEnvironment.Environment.OS.IsWindows;

            if (true) ;
        }
    }
}
