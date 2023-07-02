using AutoMapper;
using ProjetoAPI.Aplicacao.DTOs;
using ProjetoAPI.Aplicacao.Interface;
using ProjetoAPI.Dominio.Entidades;
using ProjetoAPI.Dominio.Interfaces;

namespace ProjetoAPI.Aplicacao.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task Cadastrar(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _clienteRepositorio.Cadastrar(cliente);
        }
        public async Task Alterar(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _clienteRepositorio.Alterar(cliente);
        }

        public async Task Deletar(int id)
        {
            await _clienteRepositorio.Deletar(id);
        }

        public ClienteDTO ObterClienteId(int id)
        {
            var cliente = _clienteRepositorio.ObterClienteId(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> ObterTodosClientes()
        {
            try
            {
                var cliente = await _clienteRepositorio.ObterTodosClientes();
                return _mapper.Map<IEnumerable<ClienteDTO>>(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
