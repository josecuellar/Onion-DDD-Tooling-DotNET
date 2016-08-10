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
            if (ad == null)
                throw (new NullReferenceException());

            if (discount <= 0)
                throw (new InvalidOperationException());

            ad.Price = ad.Price.DecreaseAmount(discount);
        }

        public void ApplyDiscount(IEnumerable<Ad> ads, int discount)
        {
            if (ads == null)
                throw (new NullReferenceException());

            if (discount <= 0)
                throw (new InvalidOperationException());

            foreach (Ad currentAd in ads)
            {
                currentAd.Price = currentAd.Price.DecreaseAmount(discount);
            }
        }

    }
}
