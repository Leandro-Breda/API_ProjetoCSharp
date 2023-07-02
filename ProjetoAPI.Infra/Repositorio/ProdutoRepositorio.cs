using Dapper;
using ProjetoAPI.Dominio.Entidades;
using ProjetoAPI.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Infra.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly IConnectionFactory _connectionFactory;
        public ProdutoRepositorio(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Produto> AlterarProduto(Produto produto)
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();
            
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@codigo", produto.Codigo, DbType.Int32);
            parametros.Add("@descricao", produto.Descricao, DbType.String);
            parametros.Add("@preco", produto.Preco, DbType.Decimal);

            await conexao.ExecuteAsync("UPDATE produto SET descricao = @descricao, preco = @preco where codigo = @codigo", parametros);
            return produto;
        }

        public async Task CadastrarProduto(Produto produto)
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@descricao", produto.Descricao, DbType.String);
            parametros.Add("@preco", produto.Preco, DbType.Decimal);

            await conexao.ExecuteAsync("insert into produto(descricao, preco) values (@descricao, @preco)", parametros);
            
        }

        public async Task DeletarProduto(int id)
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@codigo", id, DbType.Int32);

            await conexao.ExecuteAsync("delete from produto where codigo = @codigo", parametros);
 
        }

        public Produto ObterProdutoID(int id)
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("@codigo", id, DbType.Int32);

            var query = conexao.QueryFirstOrDefault<Produto>("select * from produto where codigo = @codigo",parametros);
            return query;
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutos()
        {
            var conexao = _connectionFactory.CreateConnectionSQLServer();

            var query = await conexao.QueryAsync<Produto>("select * from produto");
            return query;
        }
    }
}
