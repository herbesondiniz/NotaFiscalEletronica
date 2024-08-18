using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Domain.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IRepositoryBase<Cliente> _repository;
		//private readonly IClienteRepository _clienteRepository;

		public ClienteService(IRepositoryBase<Cliente> repository)			
		{
			_repository = repository;
		}

		public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
		{
			return clientes.Where(c => c.ClienteEspecial(c));
		}
	}
}
