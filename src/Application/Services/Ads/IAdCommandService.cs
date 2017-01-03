using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;
using Application.Services.Ads.DTO;


namespace Application.Services.Ads
{
    public interface IAdCommandService
    {
        Task<bool> CreateNewAd(AdDto adDto);

        Task<bool> ChangePriceAndSaveAd(AdId adId, int price, string isoCode);

        //AdDto ChangePostalCode(string advId, string code);
    }
}
