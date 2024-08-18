using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
	public interface IProdutoService : IServiceBase<Produto>
	{
		Task<IEnumerable<Produto>> BuscarPorNome(string nome);
	}
}
