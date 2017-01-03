using Domain.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model.Ads
{
    public class AdCreated : IAdCreated 
    {
        public Ad ad {get;set;}

        public DateTime OccurredOn { get; set; }

        public AdCreated(Ad ad)
        {
            this.ad = ad;
            this.OccurredOn = DateTime.Now;
        }


        
    }
}
