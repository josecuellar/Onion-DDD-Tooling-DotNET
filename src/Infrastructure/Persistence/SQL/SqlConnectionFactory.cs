using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace Persistence.SQL
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private readonly string ConnectionString;

        public SqlConnectionFactory(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw (new NoNullAllowedException("ConnectionString for SQL connection is mandatory"));

            ConnectionString = connectionString;
        }

        public IDbConnection Create()
        {
            DbConnection dbConnection = new SqlConnection(ConnectionString);

            dbConnection.Open();

            return dbConnection;
        }
    }
}