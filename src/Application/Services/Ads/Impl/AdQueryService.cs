using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Services;
using Domain.Core.Model.Ads;
using Application.Services.Ads.DTO;

namespace Application.Services.Ads
{
    public class AdQueryService : IAdQueryService
    {
        private IAdQueryRepository adQueryRepository;

        public AdQueryService(IAdQueryRepository adQueryRepository)
        {
             this.adQueryRepository = adQueryRepository;
        }

        public AdDto GetAdTitleContainsAndApplyDiscount(string searchWord, int discount)
        {
            Ad ad = this.adQueryRepository.GetBySearchText(searchWord);

            ad.ApplyDiscount(discount);

            //TO-DO: Configure Mapper interface & provider
            return new Ads.DTO.AdDto()
            {
                Id = ad.Id.Id,
                Amount = ad.Price.Amount,
                IsoCode = ad.Price.Currency.Iso.ToString()
            };
            //*
        }


        public AdDto GetAdAndApplyDiscount(string adId, int discount)
        {
            Ad ad = this.adQueryRepository.GetById(new AdId(adId));

            ad.ApplyDiscount(discount);

            //TO-DO: Configure Mapper interface & provider
            return new Ads.DTO.AdDto()
            {
                Id = ad.Id.Id,
                Amount = ad.Price.Amount,
                IsoCode = ad.Price.Currency.Iso.ToString()
            };
            //*
        }

       
    }
}
