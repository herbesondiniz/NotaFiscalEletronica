using ProjetoModeloDDD.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
	public interface IClienteService
	{
		IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
	}
}
