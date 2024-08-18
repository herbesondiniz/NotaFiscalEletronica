using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interface
{
	public interface IClienteAppService
	{
		Task<IEnumerable<Cliente>> ObterClientesEspeciais();
	}
}
