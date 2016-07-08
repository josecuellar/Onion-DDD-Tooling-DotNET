using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Offer
{
    public interface IOfferService
    {

        bool SaveInPrivateArea(Domain.Model.Offer offer, int discount);

    }
}
