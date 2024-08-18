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
    public class GrupoImpostosService: ServiceBase<GrupoImpostos>, IGrupoImpostosService
	{
		private readonly IGrupoImpostosRepository _grupoImpostosRepository;

		public GrupoImpostosService(IGrupoImpostosRepository grupoImpostosRepository) :
			base(grupoImpostosRepository)
		{
			_grupoImpostosRepository = grupoImpostosRepository;
		}

		public async Task<IEnumerable<GrupoImpostos>> GetAll() 
		{
			return await _grupoImpostosRepository.GetAll();
		}
	}
}
