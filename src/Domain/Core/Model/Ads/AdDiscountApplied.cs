using Domain.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model.Ads
{
    public class AdDiscountApplied : IAdDiscountApplied 
    {
        public int Amount { get; set; }

        public DateTime OccurredOn { get; set; }

        public AdDiscountApplied(int amount)
        {
            this.Amount = amount;
            this.OccurredOn = DateTime.Now;
        }
         
    }
}
