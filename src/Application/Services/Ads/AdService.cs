using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services.Ads;

namespace Application.Services.Ads
{
    public class AdService : IAdService
    {
        private IAdDomainService adDomainService;

        public AdService(IAdDomainService adDomainService)
        {
            this.adDomainService = adDomainService;
        }

        public bool SaveInPrivateArea()
        {
            throw new NotImplementedException();
        }
    }
}
