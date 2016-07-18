using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace Persistence.SQL
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create()
        {
            DbConnection dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringKey"].ConnectionString);

            dbConnection.Open();

            return dbConnection;
        }
    }
}