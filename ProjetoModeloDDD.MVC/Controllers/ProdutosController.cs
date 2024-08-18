using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
		private readonly IProdutoAppService _produtoApp;
		private readonly IClienteAppService _clienteApp;
		private readonly IAppServiceBase<Cliente> _appBase;
		private readonly IProdutoAppServiceExtensao _pas;

		public ProdutosController(IProdutoAppService produtoApp, IClienteAppService clienteApp, IProdutoAppServiceExtensao pas, IAppServiceBase<Cliente> appBase)
		{
			_produtoApp = produtoApp;
			_clienteApp = clienteApp;
			_pas = pas;
			_appBase = appBase;
		}
		// GET: Produtos
		public async Task<ActionResult> Index()
		{
			//_pas.Somar(5);
			IEnumerable<Produto> produtos = await _produtoApp.GetAll();

			foreach (var item in produtos)
			{
				item.Cliente = await _appBase.GetById(item.ClienteId);
			}
			
			var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtos);				
			return View(produtoViewModel);
		}

		// GET: Produtos/Details/5
		public async Task<ActionResult> Details(int id)
		{
			var produto = await _produtoApp.GetById(id);          

			var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

			return View(produtoViewModel);
		}

		// GET: Produtos/Create
		public async Task<ActionResult> Create()
		{
			ViewBag.ClienteId = new SelectList(await _appBase.GetAll(), "ClienteId", "Nome");
			return View();
		}

		// POST: Produtos/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(ProdutoViewModel produto)
		{
			if (ModelState.IsValid)
			{
				var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
				_produtoApp.Add(produtoDomain);				

				return RedirectToAction("index");
			}

			ViewBag.ClienteId = new SelectList(await _appBase.GetAll(), "ClienteId", "Nome", produto.ClienteId);

			return View(produto);
		}

		// GET: Produtos/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			var produto = await _produtoApp.GetById(id);
			var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

			ViewBag.ClienteId = new SelectList(await _appBase.GetAll(), "ClienteId", "Nome", produto.ClienteId);

			return View(produtoViewModel);
		}

		// POST: Produtos/Edit/5  
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(ProdutoViewModel produto)
		{
			if (ModelState.IsValid)
			{
				var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
				_produtoApp.Update(produtoDomain);

				return RedirectToAction("index");
			}

			ViewBag.ClienteId = new SelectList(await _appBase.GetAll(), "ClienteId", "Nome", produto.ClienteId);

			return View(produto);
		}

		// GET: Produtos/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			var produto = await _produtoApp.GetById(id);
			var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

			return View(produtoViewModel);
		}

		// POST: Produtos/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var produto = await _produtoApp.GetById(id);
			_produtoApp.Remove(produto);

			return RedirectToAction("Index");
		}
	}
}