using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class GrupoImpostosAppService: AppServiceBase<GrupoImpostos>, IGrupoImpostosAppService
    {
        private readonly IGrupoImpostosService _grupoImpostosService;
        public GrupoImpostosAppService(IGrupoImpostosService grupoImpostosService)
            : base(grupoImpostosService)
        {
            _grupoImpostosService = grupoImpostosService;
        }
    }
}
