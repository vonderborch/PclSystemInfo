using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclSystemInfo.Helpers
{
    public static class Convertors
    {
        public static int StringToInt(string value, int defaultValue)
        {
            int output = 0;
            if (int.TryParse(value, out output))
                return output;
            return defaultValue;
        }

        public static long StringToLong(string value, long defaultValue)
        {
            long output = 0;
            if (long.TryParse(value, out output))
                return output;
            return defaultValue;
        }

        public static double StringToDouble(string value, double defaultValue)
        {
            double output = 0;
            if (double.TryParse(value, out output))
                return output;
            return defaultValue;
        }
    }
}
