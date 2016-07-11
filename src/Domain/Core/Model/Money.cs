using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model
{
    /// <summary>
    /// Value Object Money. Inmutable. 
    /// </summary>
    public class Money
    {

        public readonly int Amount;

        public readonly Currency Currency;

        public Money(int amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public Money IncreaseAmount(int amount)
        {
            return new Money(
                this.Amount + amount, 
                new Currency(Model.Currency.IsoCode.EUR));
        }

        public Money DecreaseAmount(int amount)
        {
            return new Money(
                this.Amount - amount,
                new Currency(Model.Currency.IsoCode.EUR));
        }

    }
}
