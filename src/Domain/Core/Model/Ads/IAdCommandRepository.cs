using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model.Ads
{
    public interface IAdCommandRepository
    {
        Task<bool> Insert(Ad ad);

        Task<bool> Update(Ad ad);

        Task<bool> Delete(Ad ad);
    }
}
