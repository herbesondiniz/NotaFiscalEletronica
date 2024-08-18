using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class UnidadeComercialAppService: AppServiceBase<UnidadeComercial>, IUnidadeComercialAppService
    {
        private readonly IUnidadeComercialService _unidadeComercialService;
        public UnidadeComercialAppService(IUnidadeComercialService unidadeComercialService)
            : base(unidadeComercialService)
        {
            _unidadeComercialService = unidadeComercialService;
        }
    }
}
