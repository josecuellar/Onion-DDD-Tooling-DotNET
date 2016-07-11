using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model.Ads
{
    public class AdNotFoundException : Exception 
    {
        public override string Message
        {
            get
            {
                return "Ad not found." + base.Message;
            }
        }
    }
}
