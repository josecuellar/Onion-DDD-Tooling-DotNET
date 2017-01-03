using Domain.Core.Event;
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
    public class Ad : BaseEntity
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

            //DomainEvent.Publish<AdCreated>(new AdCreated(this));
            this.AddEvent((IAdCreated)new AdCreated(this));
        }

       

        public void ChangePrice(int amount, Currency.IsoCode isoCode)
        {
            this.Price = new Money(amount, new Currency(isoCode));

            this.AddEvent((IAdPriceChanged)new AdPriceChanged(this.Id, this.Price));
            //DomainEvent.Publish<AdPriceChanged>(new AdPriceChanged(this.Id, this.Price));

        }

        public void ApplyDiscount(int discount)
        {
            if (discount <= 0)
                throw (new InvalidOperationException());

            this.Price = this.Price.DecreaseAmount(discount);

            this.AddEvent((IAdDiscountApplied)new AdDiscountApplied(this.Price.Amount));
        }

        
    }

}
