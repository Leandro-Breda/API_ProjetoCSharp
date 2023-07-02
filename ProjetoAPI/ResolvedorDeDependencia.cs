using ProjetoAPI.Aplicacao.Interface;
using ProjetoAPI.Aplicacao.Service;
using ProjetoAPI.Dominio.Interfaces;
using ProjetoAPI.Infra.Configuracao;
using ProjetoAPI.Infra.Repositorio;

namespace ProjetoAPI
{
    public static class ResolvedorDeDependencia
    {
        public static void AdicionaDependencias(this IServiceCollection services)
        {
            RegistraDependenciasDeInterfaces(services);
        }

        private static void RegistraDependenciasDeInterfaces(IServiceCollection services)
        {
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
