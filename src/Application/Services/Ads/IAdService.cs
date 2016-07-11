using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;


namespace Application.Services.Ads
{
    public interface IAdService
    {
        bool SaveInPrivateArea();

        IEnumerable<Ad> GetAllAdsAndApplyDiscount(int discount);
    }
}
