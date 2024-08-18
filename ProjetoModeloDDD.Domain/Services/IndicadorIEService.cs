using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class IndicadorIEService : ServiceBase<IndicadorIE>, IIndicadorIEService
    {
        private readonly IIndicadorIERepository _indicadorIERepository;
        public IndicadorIEService(IIndicadorIERepository indicadorIERepository) : base(indicadorIERepository)
        {
            _indicadorIERepository = indicadorIERepository;
        }
    }
}
