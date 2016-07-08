using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Ads
{

    /// <summary>
    /// Entity class Ad.
    /// </summary>
    public class Ad
    {

        public readonly AdId Id;

        public readonly Money Price;

        public Ad(AdId id, Money price)
        {
            this.Id = id;
            this.Price = price;
        }

    }

}
