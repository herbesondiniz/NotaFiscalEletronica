using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Infra.Data.Contexto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
	public class ProdutoRepository: RepositoryBase<Produto>, IProdutoRepository
	{		    
        public async Task<IEnumerable<Produto>> BuscarPorNome(string nome)
		{						
			using (var Db = new ProjetoModeloContext())
			{
				return await Db.Produtos.Where(p => p.Nome == nome).ToArrayAsync();
			}			
		}
	}
}
