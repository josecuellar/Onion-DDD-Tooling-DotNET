using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model
{

    /// <summary>
    /// Value Object Currency. Inmutable. 
    /// </summary>
    public class Currency
    {

        public enum IsoCode
        {
            EUR,
            USD
        }

        public readonly IsoCode Iso;

        public Currency(IsoCode iso)
        {
            this.Iso = iso;
        }
        
    }
}
