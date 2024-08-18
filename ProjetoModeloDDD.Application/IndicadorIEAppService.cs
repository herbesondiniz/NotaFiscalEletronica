using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class IndicadorIEAppService: AppServiceBase<IndicadorIE>, IIndicadorIEAppService
    {
        private readonly IIndicadorIEService _indicadorIEService;
        public IndicadorIEAppService(IIndicadorIEService indicadorIEService) : base(indicadorIEService) 
        {
            _indicadorIEService = indicadorIEService;
        }
    }
}
