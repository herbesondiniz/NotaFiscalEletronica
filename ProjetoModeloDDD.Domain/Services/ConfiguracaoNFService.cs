using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ConfiguracaoNFService: ServiceBase<ConfiguracaoNF>, IConfiguracaoNFService
    {
        private readonly IConfiguracaoNFRepository _configuracaoNFRepository;

        public ConfiguracaoNFService(IConfiguracaoNFRepository configuracaoNFRepository) :
            base(configuracaoNFRepository)
        {
            _configuracaoNFRepository = configuracaoNFRepository;
        }
    }
}
