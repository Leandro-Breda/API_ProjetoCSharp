using ProjetoAPI.Aplicacao.DTOs;
using ProjetoAPI.Dominio.Entidades;

namespace ProjetoAPI.Aplicacao.Interface
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> ObterTodosProdutos();
        ProdutoDTO ObterProdutoID(int id);
        Task CadastrarProduto(ProdutoDTO produtoDTO);
        Task AlterarProduto(ProdutoDTO produtoDTO);
        Task DeletarProduto(int id);
    }
}
