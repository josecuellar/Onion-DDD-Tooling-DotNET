using Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Services
{
    public interface IPostalCodeAdapter
    {
        PostalCode GetByCode(string code);
    }
}
