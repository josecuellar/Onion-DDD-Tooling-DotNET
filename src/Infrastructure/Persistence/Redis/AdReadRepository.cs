using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;

namespace Persistence.Redis
{
    public class AdReadRepository : IAdReadRepository
    {
        public Ad GetById(AdId id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ad> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
