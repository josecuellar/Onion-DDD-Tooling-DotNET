using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IDemandDomainService
    {
        bool ApplyDiscount(Domain.Model.Demand demand, int discount);
    }
}
