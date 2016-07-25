using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Services.Ads;
using Domain.Core.Model.Ads;

namespace Application.Services.Ads
{
    public class AdService : IAdService
    {
        private IAdDomainService adDomainService;
        private IAdReadRepository adRepository;

        public AdService(IAdDomainService adDomainService, IAdReadRepository adRepository)
        {
            this.adDomainService = adDomainService;
            this.adRepository = adRepository;
        }

        public bool SaveInPrivateArea()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdDto> GetAllAdsAndApplyDiscount(int discount)
        {
            //throw new NotImplementedException();

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
    }
}
