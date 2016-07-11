using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model.Ads
{
    public interface IAdCommandRepository
    {
        bool Insert(Ad ad);

        bool Update(Ad ad);

        bool Delete(Ad ad);
    }
}
