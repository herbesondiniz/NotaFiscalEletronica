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
	public class ProdutoAppServiceExtensao : AppServiceBase<Produto>, IProdutoAppServiceExtensao
	{
		private readonly IProdutoService _produtoService;

		public ProdutoAppServiceExtensao(IProdutoService produtoService)
			: base(produtoService)
		{
			_produtoService = produtoService;
		}	
		public async Task<int> Somar(int valor)
		{
			var ret = await _produtoService.GetById(1);
			return 1 + 1 + (int)ret.Valor;
		}
	}
}
