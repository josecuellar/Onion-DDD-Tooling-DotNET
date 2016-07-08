using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IOfferDomainService
    {
        bool ApplyDiscount(Domain.Model.Offer demand, int discount);
    }
}
