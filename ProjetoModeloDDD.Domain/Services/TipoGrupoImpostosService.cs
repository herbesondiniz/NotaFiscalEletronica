using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class TipoGrupoImpostosService: ServiceBase<TipoGrupoImpostos>, ITipoGrupoImpostosService
	{
		private readonly ITipoGrupoImpostosRepository _tipoGrupoImpostosRepository;

		public TipoGrupoImpostosService(ITipoGrupoImpostosRepository tipoGrupoImpostosRepository) :
			base(tipoGrupoImpostosRepository)
		{
			_tipoGrupoImpostosRepository = tipoGrupoImpostosRepository;
		}		
	}
}
