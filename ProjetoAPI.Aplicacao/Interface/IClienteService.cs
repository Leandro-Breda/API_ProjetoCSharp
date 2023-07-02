using ProjetoAPI.Aplicacao.DTOs;

namespace ProjetoAPI.Aplicacao.Interface
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ObterTodosClientes();
        ClienteDTO ObterClienteId(int id);
        Task Cadastrar(ClienteDTO clienteDTO);
        Task Alterar(ClienteDTO clienteDTO);
        Task Deletar(int id);
    }
}
