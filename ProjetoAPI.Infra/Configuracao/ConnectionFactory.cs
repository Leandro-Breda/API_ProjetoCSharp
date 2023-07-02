using Microsoft.Extensions.Configuration;
using ProjetoAPI.Dominio.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoAPI.Infra.Configuracao
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnectionSQLServer()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
