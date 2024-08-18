using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ContabilidadeService : ServiceBase<Contabilidade>, IContabilidadeService
    {
        private readonly IContabilidadeRepository _contabilidadeRepository;
        public ContabilidadeService(IContabilidadeRepository contabilidadeRepository) :
            base(contabilidadeRepository)
        {
            _contabilidadeRepository = contabilidadeRepository;
        }
      
    }
}
