using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Model.Ads;
using Domain.Core.Model;

namespace Persistence.InMemory
{
    public class AdReadRepository : IAdReadRepository
    {
        public Ad GetById(AdId id)
        {

            

            //throw new NotImplementedException();
            return new Ad(new AdId("123-236"), new Money(200, new Currency(Currency.IsoCode.EUR)));
        }

        public IEnumerable<Ad> GetAll()
        {
            //throw new NotImplementedException();

            List<Ad> listExample = new List<Ad>();
            listExample.Add(new Ad(new AdId("123-236"), new Money(200, new Currency(Currency.IsoCode.EUR))));
            listExample.Add(new Ad(new AdId("123-237"), new Money(210, new Currency(Currency.IsoCode.EUR))));
            listExample.Add(new Ad(new AdId("123-238"), new Money(220, new Currency(Currency.IsoCode.EUR))));
            listExample.Add(new Ad(new AdId("123-239"), new Money(230, new Currency(Currency.IsoCode.EUR))));

            return listExample;

        }
    }
}
