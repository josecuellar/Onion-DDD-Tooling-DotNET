using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public interface IDemandRepository
    {
        bool Insert(Domain.Model.Demand demand);
    }
}
