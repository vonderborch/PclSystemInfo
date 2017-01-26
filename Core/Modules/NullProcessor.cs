using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclSystemInfo.Modules
{
    public class NullProcessor : AProcessor
    {
        public override string ProcessorName
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
