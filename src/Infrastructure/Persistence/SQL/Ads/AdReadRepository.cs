using System.Collections.Generic;
using System.Linq;
using Domain.Core.Model.Ads;
using System.Data;
using Persistence.SQL.Ads.QueryObjects;

namespace Persistence.SQL.Ads
{
    public class AdReadRepository : IAdReadRepository
    {
        private readonly IConnectionFactory connection;
        private readonly Cache.ICache<IEnumerable<Ad>> cacheRepository;

        public AdReadRepository(IConnectionFactory connectionFactory)
        {
            this.connection = connectionFactory;
        }

        public Ad GetById(AdId advId)
        {
            IEnumerable<Ad> adToReturn = cacheRepository.Get("Ad" + advId.Id);
            if (adToReturn.SingleOrDefault() != null)
                return adToReturn.SingleOrDefault();

            using (IDbConnection dbConnection = connection.Create())
            {
                QueryObject byId = new AdSelect().ById(advId.Id);
                adToReturn = dbConnection.Query<Ad>(byId);

                cacheRepository.Set("Ad" + advId.Id, adToReturn);
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
