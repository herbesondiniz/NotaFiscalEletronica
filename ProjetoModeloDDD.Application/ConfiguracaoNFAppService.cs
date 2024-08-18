using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class ConfiguracaoNFAppService : AppServiceBase<ConfiguracaoNF>, IConfiguracaoNFAppService
    {
        private readonly IConfiguracaoNFService _configuracaoNFService;

        public ConfiguracaoNFAppService(IConfiguracaoNFService configuracaoNFService)
            : base(configuracaoNFService)
        {
            _configuracaoNFService = configuracaoNFService;
        }
    }
}
