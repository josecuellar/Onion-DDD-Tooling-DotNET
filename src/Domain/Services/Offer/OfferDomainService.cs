using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OfferDomainService : IOfferDomainService
    {

        bool IOfferDomainService.ApplyDiscount(Domain.Model.Offer offer, int discount)
        {
            throw new NotImplementedException();
        }

    }
}
