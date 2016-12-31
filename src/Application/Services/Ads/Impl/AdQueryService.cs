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
    public class AdQueryService : IAdQueryService
    {
        private IAdDomainService adDomainService;
        private IAdQueryRepository adQueryRepository;

        public AdQueryService(IAdDomainService adDomainService,
                         IAdQueryRepository adQueryRepository)
        {
            this.adDomainService = adDomainService;
            this.adQueryRepository = adQueryRepository;
        }

        public IEnumerable<AdDto> GetAdsTitleContainsAndApplyDiscount(string searchWord, int discount)
        {
            IEnumerable<Ad> ads = this.adQueryRepository.GetAllBySearchText(searchWord);

            this.adDomainService.ApplyDiscount(ads, discount);

            //TO-DO: Configure Mapper interface & provider
            return ads.ToList().ConvertAll(src => new Ads.DTO.AdDto()
            {
                Id = src.Id.Id,
                Amount = src.Price.Amount,
                IsoCode = src.Price.Currency.Iso.ToString()
            });
            //*
        }


        public IEnumerable<AdDto> GetAllAdsAndApplyDiscount(int discount)
        {
            if (discount <= 0)
                throw new InvalidOperationException();

            IEnumerable<Ad> ads = this.adQueryRepository.GetAll();

            this.adDomainService.ApplyDiscount(ads, discount);

            //TO-DO: Configure Mapper interface & provider
            return ads.ToList().ConvertAll(src => new Ads.DTO.AdDto()
            {
                Id = src.Id.Id,
                Amount = src.Price.Amount,
                IsoCode = src.Price.Currency.Iso.ToString()
            });
            //*
        }

       
    }
}
