using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Offer
{
    public class OfferService : IOfferService
    {
        private Domain.Services.IOfferDomainService offerDomainService;
        private Domain.Model.IOfferRepository offerRepository;

        public OfferService(Domain.Services.IOfferDomainService offerDomainService,
                            Domain.Model.IOfferRepository offerRepository)
        {
            this.offerDomainService = offerDomainService;
            this.offerRepository = offerRepository;
        }

        public bool SaveInPrivateArea(Domain.Model.Offer offer, int discount)
        {
            this.offerDomainService.ApplyDiscount(offer, discount);
            this.offerRepository.Insert(offer);
            return true;
        }
    }
}
