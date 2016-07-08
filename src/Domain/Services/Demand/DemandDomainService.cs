using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class DemandDomainService : IDemandDomainService
    {
        //Methods CRUD and business domain rules for demand
        bool IDemandDomainService.ApplyDiscount(Domain.Model.Demand demand, int discount)
        {
            throw new NotImplementedException();
        }
    }
}
