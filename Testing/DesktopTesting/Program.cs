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
            var x = WMI.GetAllWmiValuesForWmiComponent("Win32_Processor");
            var y = WMI.GetAllWmiValuesForWmiComponent("Win32_VideoController");

            foreach (var yi in y)
            {
                File.AppendAllText(@"C:\Temp\Win32_VideoController.txt", yi.Key);
                foreach (var yij in yi.Value)
                {
                    File.AppendAllText(@"C:\Temp\Win32_VideoController.txt", $"{yij.Key} : {yij.Value}{Environment.NewLine}");
                }
                File.AppendAllText(@"C:\Temp\Win32_VideoController.txt", $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
            }

            if (true) ;
        }
    }
}
