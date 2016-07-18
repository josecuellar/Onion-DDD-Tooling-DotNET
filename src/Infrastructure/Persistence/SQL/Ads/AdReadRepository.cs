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

        public AdReadRepository(IConnectionFactory connectionFactory)
        {
            this.connection = connectionFactory;
        }

        public Ad GetById(AdId advId)
        {
            using (IDbConnection dbConnection = connection.Create())
            {
                QueryObject byId = new AdSelect().ById(advId.Id);
                Ad adToReturn = dbConnection.Query<Ad>(byId).SingleOrDefault();
                return adToReturn;
            }
        }

        public IEnumerable<Ad> GetAll()
        {
            using (IDbConnection dbConnection = connection.Create())
            {
                QueryObject byAll = new AdSelect().All();
                IEnumerable<Ad> adToReturn = dbConnection.Query<Ad>(byAll);
                return adToReturn;
            }
        }
    }
}
