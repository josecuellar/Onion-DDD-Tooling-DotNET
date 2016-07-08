using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Ads;

namespace Domain.Services.Ads
{
    public interface IAdDomainService
    {
        bool ApplyDiscount(Ad demand, int discount);
    }
}
