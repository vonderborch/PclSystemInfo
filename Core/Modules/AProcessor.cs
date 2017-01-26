using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclSystemInfo.Modules
{
    public abstract class AProcessor
    {
        public int ProcessorCount
        {
            get { return Environment.ProcessorCount; }
        }

        public abstract string ProcessorName { get; }
    }
}
