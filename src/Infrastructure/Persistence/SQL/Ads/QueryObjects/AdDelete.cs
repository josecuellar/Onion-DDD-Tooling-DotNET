

namespace Persistence.SQL.Ads.QueryObjects
{
    internal class AdDelete
    {
        public QueryObject All()
        {
            return new QueryObject("delete from Product");
        }

        public QueryObject ById(string adId)
        {
            return new QueryObject(All().Sql + @" where p.AdId = @Id", new { Id = adId });
        }

    }
}