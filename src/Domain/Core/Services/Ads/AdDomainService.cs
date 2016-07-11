using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;

namespace Domain.Core.Services.Ads
{
    public class AdDomainService : IAdDomainService
    {

        public void ApplyDiscount(Ad ad, int discount)
        {
            ad.Price = ad.Price.DecreaseAmount(discount);
        }

        public void ApplyDiscount(IEnumerable<Ad> ads, int discount)
        {
            foreach(Ad currentAd in ads)
            {
                currentAd.Price = currentAd.Price.DecreaseAmount(discount);
            }
        }

    }
}
