using ProjetoAPI.Dominio.Entidades;

namespace ProjetoAPI.Dominio.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<IEnumerable<Produto>> ObterTodosProdutos();
        Produto ObterProdutoID(int id);
        Task CadastrarProduto(Produto produto);
        Task<Produto> AlterarProduto(Produto produto);
        Task DeletarProduto(int id);
    }
}
