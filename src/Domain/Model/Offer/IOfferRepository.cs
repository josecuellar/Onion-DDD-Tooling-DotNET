using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IOfferRepository
    {
        bool Insert(Domain.Model.Offer offer);
    }
}
