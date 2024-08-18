using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class UnidadeComercialService: ServiceBase<UnidadeComercial>, IUnidadeComercialService
    {
        private readonly IUnidadeComercialRepository _unidadeComercialRepository;
        public UnidadeComercialService(IUnidadeComercialRepository unidadeComercialRepository) :
            base(unidadeComercialRepository)
        {
            _unidadeComercialRepository = unidadeComercialRepository;
        }
    }
}
