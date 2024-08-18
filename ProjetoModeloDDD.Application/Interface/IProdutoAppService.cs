using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interface
{
	public interface IProdutoAppService : IAppServiceBase<Produto>
	{
		Task<IEnumerable<Produto>> BuscarPorNome(string nome);
	}
}
