using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces
{
	public interface IProdutoRepository : IRepositoryBase<Produto>
	{
		Task<IEnumerable<Produto>> BuscarPorNome(string nome);
	}
}
