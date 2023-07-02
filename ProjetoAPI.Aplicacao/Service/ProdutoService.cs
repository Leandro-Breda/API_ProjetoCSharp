using AutoMapper;
using ProjetoAPI.Aplicacao.DTOs;
using ProjetoAPI.Aplicacao.Interface;
using ProjetoAPI.Dominio.Entidades;
using ProjetoAPI.Dominio.Exceptions;
using ProjetoAPI.Dominio.Interfaces;

namespace ProjetoAPI.Aplicacao.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }

        public async Task CadastrarProduto(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);

            if (produtoDTO.Preco <= 0)
            {
                throw new ValorNegativoException("O preço do produto precisa ser maior que zero");
            }
            if (produtoDTO.Descricao.Length < 3)
            {
               throw new ArgumentOutOfRangeException("Descrição precisa ter no minímo 3 caracteres.");
            }

            await _produtoRepositorio.CadastrarProduto(produto);

        }

        public async Task AlterarProduto(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepositorio.AlterarProduto(produto);
        }

        public async Task DeletarProduto(int id)
        {
            await _produtoRepositorio.DeletarProduto(id);

        }

        public ProdutoDTO ObterProdutoID(int id)
        {
            var produto = _produtoRepositorio.ObterProdutoID(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterTodosProdutos()
        {
            try
            {
                var produto = await _produtoRepositorio.ObterTodosProdutos();
                return _mapper.Map<IEnumerable<ProdutoDTO>>(produto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
