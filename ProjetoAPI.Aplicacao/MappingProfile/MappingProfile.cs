using AutoMapper;
using ProjetoAPI.Aplicacao.DTOs;
using ProjetoAPI.Dominio.Entidades;

namespace ProjetoAPI.Aplicacao.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Produto, ProdutoDTO>();
            CreateMap<ProdutoDTO, Produto>();
        }

    }
}
