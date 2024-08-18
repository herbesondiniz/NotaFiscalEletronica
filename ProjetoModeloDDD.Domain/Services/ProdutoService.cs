using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
	public class ProdutoService : ServiceBase<Produto>, IProdutoService //estende (herda) a classe implementada ServiceBase e implementa a interface IProdutoService
	{
		private readonly IProdutoRepository _produtoRepository;		

		public ProdutoService(IProdutoRepository produtoRepository) :
			base(produtoRepository)
		{
			_produtoRepository = produtoRepository;			
		}

		public async Task<IEnumerable<Produto>> BuscarPorNome(string nome)
		{
			return await _produtoRepository.BuscarPorNome(nome);
		}
	}
}
