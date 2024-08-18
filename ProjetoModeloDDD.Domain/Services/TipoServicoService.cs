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
    public class TipoServicoService: ServiceBase<TipoServico>, ITipoServicoService
	{
		private readonly ITipoServicoRepository _tipoServicoRepository;

		public TipoServicoService(ITipoServicoRepository tipoServicoRepository) :
			base(tipoServicoRepository)
		{
			_tipoServicoRepository = tipoServicoRepository;
		}
	}
}
