using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
	public class ClienteAppService : IClienteAppService
	{
		private readonly IServiceBase<Cliente> _serviceBase;
		private readonly IClienteService _serviceCliente;
		public ClienteAppService(IServiceBase<Cliente> serviceBase, IClienteService serviceCliente) 			
		{
			_serviceBase = serviceBase;
			_serviceCliente = serviceCliente;
		}

		public async Task<IEnumerable<Cliente>> ObterClientesEspeciais()
		{
			return _serviceCliente.ObterClientesEspeciais(await _serviceBase.GetAll());
		}
	
	}
}
