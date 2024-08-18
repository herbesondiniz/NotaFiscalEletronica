using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class CFOPAppService: AppServiceBase<CFOP>, ICFOPAppService
    {
		private readonly ICFOPService _CFOPService;
		public CFOPAppService(ICFOPService CFOPService)
			: base(CFOPService)
		{
			_CFOPService = CFOPService;
		}

        public async Task<IEnumerable<CFOP>> BuscarPorTipoGrupoImpostosId(int id)
        {
            return await _CFOPService.BuscarPorTipoGrupoImpostosId(id);
        }
    }
}
