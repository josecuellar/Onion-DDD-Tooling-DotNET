
namespace Persistence.SQL.Ads.QueryObjects
{
    internal class AdSelect
    {
        public QueryObject All()
        {
            return new QueryObject(@"select p.AdId as Id,
                                            p.Name
                                     from Ad p ");
        }

        public QueryObject ById(string adId)
        {
            return new QueryObject(All().Sql + @" where p.AdId = @Id", new { Id = adId });
        }

    }
}