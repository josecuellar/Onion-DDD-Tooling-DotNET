using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class DemandNotFoundException : Exception 
    {
        public override string Message
        {
            get
            {
                return "Not found demand." + base.Message;
            }
        }
    }
}
