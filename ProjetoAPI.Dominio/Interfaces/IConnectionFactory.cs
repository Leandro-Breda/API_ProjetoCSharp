using System.Data;

namespace ProjetoAPI.Dominio.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnectionSQLServer();
    }
}
