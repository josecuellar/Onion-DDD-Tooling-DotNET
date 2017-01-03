using Domain.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model.Ads
{
    public class AdPriceChanged : IAdPriceChanged 
    {
        public AdId AdId { get; set; }

        public Money ToPrice { get; set; }

        public DateTime OccurredOn { get; set; }

        public AdPriceChanged(AdId adId, Money toPrice)
        {
            this.AdId = adId;
            this.ToPrice = toPrice;
            this.OccurredOn = DateTime.Now;
        }
         
    }
}
