using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Services.Ads;
using Domain.Core.Services;
using Domain.Core.Model.Ads;
using Application.Services.Ads.DTO;

namespace Application.Services.Ads
{
    public class AdCommandService : IAdCommandService
    {
        private IAdDomainService adDomainService;
        private IAdCommandRepository adCommandRepository;
        //private IPostalCodeAdapter postalCodeAdapter;

        //public AdCommandService(IAdDomainService adDomainService,
        //                 IAdCommandRepository adCommandRepository,
        //                 IPostalCodeAdapter postalCodeAdapter)

       public AdCommandService(IAdDomainService adDomainService,
                         IAdCommandRepository adCommandRepository)
        {
            this.adDomainService = adDomainService;
            this.adCommandRepository = adCommandRepository;
            //this.postalCodeAdapter = postalCodeAdapter;
        }

        public async Task<int> CreateNewAd(AdDto adDto)
        {
            return this.adCommandRepository.Insert(new Ad(new AdId(adDto.Id),
                           new Domain.Core.Model.Money(adDto.Amount, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)),
                           new Domain.Core.Model.Coords(1.34343432, 3.44546),
                           new Domain.Core.Model.PostalCode(adDto.PostalCode),
                           "Title 1"));
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
    }
}
