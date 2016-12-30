
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

        public QueryObject AllBySearchText(string text)
        {
            return new QueryObject(All().Sql + @" where p.Name LIKE '%@Name%'", new { Name = text });
        }

        public QueryObject ById(string adId)
        {
            return new QueryObject(All().Sql + @" where p.AdId = @Id", new { Id = adId });
        }

    }
}