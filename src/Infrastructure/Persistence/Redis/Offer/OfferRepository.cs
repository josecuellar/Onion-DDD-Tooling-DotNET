using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Persistence.Redis.Offer
{
    public class OfferRepository : Domain.Model.IOfferRepository
    {
        bool IOfferRepository.Insert(Domain.Model.Offer offer)
        {
            throw new NotImplementedException();
        }
    }
}
