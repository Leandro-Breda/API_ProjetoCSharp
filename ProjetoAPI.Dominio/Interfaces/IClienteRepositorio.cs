using ProjetoAPI.Dominio.Entidades;

namespace ProjetoAPI.Dominio.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable<Cliente>> ObterTodosClientes();
        Cliente ObterClienteId(int id);
        Task<Cliente> Cadastrar(Cliente cliente);
        Task<Cliente> Alterar(Cliente cliente);
        Task Deletar(int id);
    }
}
