using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Services;
using Domain.Core.Model.Ads;
using Application.Services.Ads.DTO;
using Domain.Core.Event;

namespace Application.Services.Ads
{
    public class AdCommandService : IAdCommandService
    {
        private IAdCommandRepository adCommandRepository;
        private IAdQueryRepository adQueryRepository;
        //private IPostalCodeAdapter postalCodeAdapter;

        //public AdCommandService(IAdDomainService adDomainService,
        //                 IAdCommandRepository adCommandRepository,
        //                 IPostalCodeAdapter postalCodeAdapter)

       public AdCommandService(IAdQueryRepository adQueryRepository,
                               IAdCommandRepository adCommandRepository)
        {
            this.adCommandRepository = adCommandRepository;
            this.adQueryRepository = adQueryRepository;
            //this.postalCodeAdapter = postalCodeAdapter;
        }

        public async Task<bool> CreateNewAd(AdDto adDto)
        {
            
            
            
            Ad ToAdd = new Ad(new AdId(adDto.Id),
                           new Domain.Core.Model.Money(adDto.Amount, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)),
                           new Domain.Core.Model.Coords(1.34343432, 3.44546),
                           new Domain.Core.Model.PostalCode(adDto.PostalCode),
                           "Title 1");

            if (await this.adCommandRepository.Insert(ToAdd))
                ToAdd.DispatchEvents();


            return true;
        }

        //public AdDto ChangePostalCode(string adId, string code)
        //{
        //    Ad ad = this.adReadRepository.GetById(new AdId(adId));
        //    ad.PostalCode = this.postalCodeAdapter.GetByCode(code);

        //    //TO-Do Save in repository & Configure Mapper interface & provider
        //    return new AdDto()
        //    {
        //        Id = ad.Id.Id,
        //        Title = ad.Title,
        //        Amount = ad.Price.Amount,
        //        IsoCode = ad.Price.Currency.Iso.ToString(),
        //        PostalCode = ad.PostalCode.Code,
        //        PostalCodeName = ad.PostalCode.Name
        //    };

        //}

        public async Task<bool> ChangePriceAndSaveAd(AdId adId, int amount, string isoCode)
        {
            Ad adToChangePriceAndSave = this.adQueryRepository.GetById(adId);
            
            Domain.Core.Model.Currency.IsoCode isoCodeEnum = (Domain.Core.Model.Currency.IsoCode)Enum.Parse(typeof(Domain.Core.Model.Currency.IsoCode), isoCode, true);

            adToChangePriceAndSave.ChangePrice(amount, isoCodeEnum);

            if (await this.adCommandRepository.Update(adToChangePriceAndSave))
                adToChangePriceAndSave.DispatchEvents();

            return true;
        }
    }
}
