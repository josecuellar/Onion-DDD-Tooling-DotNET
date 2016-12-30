using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;
using Application.Services.Ads.DTO;


namespace Application.Services.Ads
{
    public interface IAdReadService
    {
        IEnumerable<AdDto> GetAllAdsAndApplyDiscount(int discount);

        IEnumerable<AdDto> GetAdsTitleContainsAndApplyDiscount(string searchText, int discount);
    }
}
