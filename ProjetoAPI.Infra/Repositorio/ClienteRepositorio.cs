using Dapper;
using ProjetoAPI.Dominio.Entidades;
using ProjetoAPI.Dominio.Interfaces;
using System.Data;

namespace ProjetoAPI.Infra.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly IConnectionFactory _connectionFactory;
        public ClienteRepositorio(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<Cliente> Cadastrar(Cliente cliente)
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@CPF", cliente.CPF, DbType.String);
            parametros.Add("@Nome", cliente.Nome, DbType.String);
            parametros.Add("@DataNascimento", cliente.DataNascimento, DbType.DateTime);
            parametros.Add("@Telefone", cliente.Telefone, DbType.String);
            parametros.Add("@Email", cliente.Email, DbType.String);

            await conexao.ExecuteAsync("INSERT INTO Cliente(CPF, Nome, DataNascimento, Telefone, Email) values(@CPF, @Nome, @DataNascimento, @Telefone, @Email)", parametros);
            
            return cliente;
        }

        public async Task<Cliente> Alterar(Cliente cliente)
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@ID", cliente.Id, DbType.Int32);
            parametros.Add("@CPF", cliente.CPF, DbType.String);
            parametros.Add("@Nome", cliente.Nome, DbType.String);
            parametros.Add("@DataNascimento", cliente.DataNascimento, DbType.DateTime);
            parametros.Add("@Telefone", cliente.Telefone, DbType.String);
            parametros.Add("@Email", cliente.Email, DbType.String);

            await conexao.ExecuteAsync("UPDATE Cliente SET CPF = @CPF, Nome = @Nome, DataNascimento = @DataNascimento, Telefone = @Telefone, Email = @Email where ID = @ID", parametros);
            return cliente;
        }

        public async Task Deletar(int id)
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();

            DynamicParameters parametro = new DynamicParameters();
            parametro.Add("@ID", id, DbType.Int32);

            var sql = await conexao.ExecuteAsync("DELETE from cliente where id = @id", parametro);


        }

        public Cliente ObterClienteId(int id)
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();

            DynamicParameters parametro = new DynamicParameters();
            parametro.Add("@id", id, DbType.Int32);

            var retorno = conexao.QueryFirstOrDefault<Cliente>("select * from cliente where id = @id", parametro);

            return retorno;
        }

        public async Task<IEnumerable<Cliente>> ObterTodosClientes()
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();

            var sql = "select * from Cliente";
            var resultado = await conexao.QueryAsync<Cliente>(sql);

            return resultado;
        }
    }
}
