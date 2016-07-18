using System.Data;

namespace Persistence.SQL
{

    /// <summary>
    ///     Factory for <see cref="IDbConnection" />
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        ///     Create <see cref="IDbConnection" />
        /// </summary>
        IDbConnection Create();
    }
}