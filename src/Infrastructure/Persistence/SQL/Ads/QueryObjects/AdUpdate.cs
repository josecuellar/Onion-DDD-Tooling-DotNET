
namespace Persistence.SQL.Ads.QueryObjects
{
    internal class AdUpdate
    {
        public QueryObject Query(object queryParams)
        {
            return new QueryObject(@"update Ads
                                     set Name = @Name, Price = @Price", queryParams);
        }

    }
}