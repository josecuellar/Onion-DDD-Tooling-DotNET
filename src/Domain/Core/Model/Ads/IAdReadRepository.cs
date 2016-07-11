using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model.Ads
{
    public interface IAdReadRepository
    {
        Ad GetById(AdId id);

        IEnumerable<Ad> GetAll();
    }
}
