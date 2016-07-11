using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;

namespace Domain.Core.Services.Ads
{
    public interface IAdDomainService
    {
        void ApplyDiscount(Ad ad, int discount);

        void ApplyDiscount(IEnumerable<Ad> ads, int discount);
    }
}
