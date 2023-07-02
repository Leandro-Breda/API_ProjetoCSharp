using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Aplicacao.DTOs;
using ProjetoAPI.Aplicacao.Interface;
using ProjetoAPI.Dominio.Exceptions;

namespace ProjetoAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Consultar produto
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Codigo}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult ObterProduto(int Codigo)
        {
            if (Codigo <= 0)
                return BadRequest();

            var produto = _produtoService.ObterProdutoID(Codigo);

            var formatarPreco = produto.Preco.ToString("N2");

            var response = new
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Preco = formatarPreco
            };

            return Ok(response);
        }

        /// <summary>
        /// Listar produtos
        /// </summary>
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("Listar")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProdutoDTO>> ListarProdutos()
        {
            var retorno = await _produtoService.ObterTodosProdutos();
            return Ok(retorno);
        }

        /// <summary>
        /// Cadastrar produto
        /// </summary>
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("Cadastrar")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult CadastrarProduto([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
                return BadRequest();

            var resposta = _produtoService.CadastrarProduto(produtoDTO);
            return Ok(resposta);

        }


        /// <summary>
        /// Alterar Cliente
        /// </summary>
        /// <param name="clienteDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Alterar")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult AlterarProduto([FromBody] ProdutoDTO produtoDTO)
        {
            _produtoService.AlterarProduto(produtoDTO);
            return Ok(produtoDTO);
        }

        /// <summary>
        /// Excluir Cliente
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Excluir")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult ExcluirProduto(int codigo)
        {
            _produtoService.DeletarProduto(codigo);
            return Ok(codigo);
        }

    }
}
