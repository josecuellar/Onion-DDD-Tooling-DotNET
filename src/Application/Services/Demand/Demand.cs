using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Demand
{
    public class DemandService : IDemandService
    {
        private Domain.Services.IDemandDomainService demandDomainService;

        public DemandService(Domain.Services.IDemandDomainService demandDomainService)
        {
            this.demandDomainService = demandDomainService;
        }

        bool IDemandService.SaveInPrivateArea()
        {
            throw new NotImplementedException();
        }
    }
}
