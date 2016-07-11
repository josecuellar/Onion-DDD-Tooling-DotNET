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

        public IEnumerable<Ad> GetAllAdsAndApplyDiscount(int discount)
        {
            //throw new NotImplementedException();

            IEnumerable<Ad> ads = this.adRepository.GetAll();

            this.adDomainService.ApplyDiscount(ads, discount);

            return ads;
            
        }
    }
}
