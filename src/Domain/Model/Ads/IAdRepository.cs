using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Ads
{
    public interface IAdRepository
    {
        bool Insert(Domain.Model.Ads.Ad adv);
    }
}
