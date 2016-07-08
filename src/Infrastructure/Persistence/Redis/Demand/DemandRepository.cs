using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Persistence.Redis.Offer
{
    public class DemandRepository : Domain.Model.IDemandRepository
    {
        bool IDemandRepository.Insert(Demand demand)
        {
            throw new NotImplementedException();
        }
    }
}
