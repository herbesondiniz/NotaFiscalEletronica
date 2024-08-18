using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
	public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
	{
		private readonly IProdutoService _produtoService;

		public ProdutoAppService(IProdutoService produtoService)
			: base(produtoService)
		{
			_produtoService = produtoService;
		}
		public async Task<IEnumerable<Produto>> BuscarPorNome(string nome)
		{			
			return await _produtoService.BuscarPorNome(nome);
		}

		public int Somar(int valor)
		{
			return 1 + 1;
		}
	}
}
