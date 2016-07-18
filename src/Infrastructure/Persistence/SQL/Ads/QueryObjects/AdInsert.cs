
namespace Persistence.SQL.Ads.QueryObjects
{
    internal class AdInsert
    {
        public QueryObject Query(object queryParameters)
        {
            return new QueryObject(@"insert into Ads(Name, Price) values (@Name, @Price);
                                     SELECT last_insert_rowid();", queryParameters);
        }
    }
}