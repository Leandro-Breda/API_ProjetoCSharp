using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Aplicacao.DTOs;
using ProjetoAPI.Aplicacao.Interface;

namespace ProjetoAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Consultar cliente
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Codigo}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult ObterCliente(int Codigo)
        {
            if (Codigo <= 0)
                return BadRequest();

            var retorno = _clienteService.ObterClienteId(Codigo);

            return Ok(retorno);
        }

        /// <summary>
        /// Listar cliente
        /// </summary>
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("Listar")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClienteDTO>> ListarClientes()
        {
                var retorno = await _clienteService.ObterTodosClientes();
                return Ok(retorno);            
        }

        /// <summary>
        /// Cadastrar Cliente
        /// </summary>
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("Cadastrar")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public  ActionResult CadastrarCliente([FromBody] ClienteDTO clienteDTO)
        {
            if (string.IsNullOrEmpty(clienteDTO.Nome) || string.IsNullOrEmpty(clienteDTO.CPF))
            {
                return BadRequest("Nome e CPF são campos obrigatórios");
            }
            _clienteService.Cadastrar(clienteDTO);

            return Ok("Cliente cadastrado com sucesso");
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

        public ActionResult AlterarCliente([FromBody] ClienteDTO clienteDTO)
        {
            _clienteService.Alterar(clienteDTO);
            return Ok(clienteDTO);
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

        public ActionResult ExcluirCliente(int codigo)
        {
            _clienteService.Deletar(codigo);
            return Ok(codigo);
        }

    }
}
