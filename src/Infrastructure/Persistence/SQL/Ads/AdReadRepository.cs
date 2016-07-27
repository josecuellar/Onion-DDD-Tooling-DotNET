using System.Collections.Generic;
using System.Linq;
using Domain.Core.Model.Ads;
using System.Data;
using Persistence.SQL.Ads.QueryObjects;
using Cache;

namespace Persistence.SQL.Ads
{
    public class AdReadRepository : IAdReadRepository
    {
        private readonly IConnectionFactory connection;
        private readonly Cache.ICache<IEnumerable<Ad>> cacheRepository;

        public AdReadRepository(IConnectionFactory connectionFactory, ICache<IEnumerable<Ad>> cacheRepository)
        {
            this.connection = connectionFactory;
            this.cacheRepository = cacheRepository;
        }

        public Ad GetById(AdId adId)
        {

            IEnumerable<Ad> adToReturn = cacheRepository.Get("Ad" + adId.Id);
            if (adToReturn != null)
                return adToReturn.SingleOrDefault();

            //TO-DO - Return fixed data. Get original repo
            adToReturn = new List<Ad>();
            adToReturn = adToReturn.ToList();
            ((List<Ad>)adToReturn).Add(new Ad(adId, new Domain.Core.Model.Money(32, new Domain.Core.Model.Currency(Domain.Core.Model.Currency.IsoCode.EUR)), new Domain.Core.Model.Coords(33, 33), new Domain.Core.Model.PostalCode("08150")));
            cacheRepository.Set("Ad" + adId.Id, adToReturn);
            return adToReturn.SingleOrDefault();
            //*

            using (IDbConnection dbConnection = connection.Create())
            {
                QueryObject byId = new AdSelect().ById(adId.Id);
                adToReturn = dbConnection.Query<Ad>(byId);

                cacheRepository.Set("Ad" + adId.Id, adToReturn);
                return adToReturn.SingleOrDefault();
            }
        }

        public IEnumerable<Ad> GetAll()
        {
            IEnumerable<Ad> adToReturn = cacheRepository.Get("Ads");
            if (adToReturn != null)
                return adToReturn;

            using (IDbConnection dbConnection = connection.Create())
            {
                QueryObject byAll = new AdSelect().All();
                adToReturn = dbConnection.Query<Ad>(byAll);

                cacheRepository.Set("Ads", adToReturn);
                return adToReturn;
            }
        }
    }
}
