using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PclSystemInfo;
using System.IO;

namespace DesktopTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = MachineEnvironment.Environment.Memory.TotalBytes;

            var x = WMI.GetAllWmiValuesForWmiComponent("Win32_Processor");
            var y = WMI.GetAllWmiValuesForWmiComponent("Win32_VideoController");
            var z = WMI.GetAllWmiValuesForWmiComponent("Win32_ComputerSystem");

            var file = @"C:\Temp\Win32_ComputerSystem.txt";
            foreach (var yi in z)
            {
                File.AppendAllText(file, yi.Key);
                foreach (var yij in yi.Value)
                {
                    File.AppendAllText(file, $"{yij.Key} : {yij.Value}{Environment.NewLine}");
                }
                File.AppendAllText(file, $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
            }

            if (true) ;
        }
    }
}
