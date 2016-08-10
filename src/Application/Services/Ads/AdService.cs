using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Services.Ads;
using Domain.Core.Services;
using Domain.Core.Model.Ads;

namespace Application.Services.Ads
{
    public class AdService : IAdService
    {
        private IAdDomainService adDomainService;
        private IAdReadRepository adRepository;
        private IPostalCodeAdapter postalCodeAdapter;

        public AdService(IAdDomainService adDomainService, 
                         IAdReadRepository adRepository,
                         IPostalCodeAdapter postalCodeAdapter)
        {
            this.adDomainService = adDomainService;
            this.adRepository = adRepository;
            this.postalCodeAdapter = postalCodeAdapter;
        }

        public bool SaveInPrivateArea()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdDto> GetAllAdsAndApplyDiscount(int discount)
        {
            if (discount <= 0)
                throw new InvalidOperationException();

            IEnumerable<Ad> ads = this.adRepository.GetAll();

            this.adDomainService.ApplyDiscount(ads, discount);

            //TO-DO: Configure Mapper interface & provider
            return ads.ToList().ConvertAll(src => new Ads.AdDto()
            {
                Id = src.Id.Id,
                Amount = src.Price.Amount,
                IsoCode = src.Price.Currency.Iso.ToString()
            });
            //*
        }

        public AdDto ChangePostalCode(string adId, string code)
        {
            Ad ad = this.adRepository.GetById(new AdId(adId));
            ad.PostalCode = this.postalCodeAdapter.GetByCode(code);

            //TO-Do Save in repository & Configure Mapper interface & provider
            return new AdDto()
            {
                Id = ad.Id.Id,
                Amount = ad.Price.Amount,
                IsoCode = ad.Price.Currency.Iso.ToString(),
                PostalCode = ad.PostalCode.Code,
                PostalCodeName = ad.PostalCode.Name
            };

        }
    }
}
