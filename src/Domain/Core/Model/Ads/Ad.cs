using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model.Ads
{

    /// <summary>
    /// Entity class Ad.
    /// </summary>
    public class Ad
    {

        public AdId Id;

        public string Title;

        public Money Price;

        public Coords Coords;

        public PostalCode PostalCode;

        public Ad(AdId id, Money price, Coords coords, PostalCode postalCode, string title)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
            this.Coords = coords;
            this.PostalCode = postalCode;
        }


    }

}
