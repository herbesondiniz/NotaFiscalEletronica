using AutoMapper;
using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
	public class ClientesController : Controller
	{
		private readonly IClienteAppService _clienteApp;
		private readonly IAppServiceBase<Cliente> _appBase;
		private readonly IProdutoAppService _produtoApp;
		public ClientesController(IClienteAppService clienteApp, IProdutoAppService produtoApp)
		{
			_clienteApp = clienteApp;
			_produtoApp = produtoApp;
		}  
		// GET: Clientes
		public async Task<ActionResult> Index()
		{
			IEnumerable<Cliente> clientes = await _appBase.GetAll();
			IEnumerable<Produto> produtos = await _produtoApp.GetAll();

			//List<Produto> p = produtos.ToList();

			foreach (var item in clientes)
			{
				item.Produtos = produtos.Where(x => x.ClienteId == item.ClienteId);
			}

			var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(await _appBase.GetAll());
			return View(clienteViewModel);
		}

		public async Task<ActionResult> Especiais()
		{
			var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(await _clienteApp.ObterClientesEspeciais());
			return View(clienteViewModel);
		}

		// GET: Clientes/Details/5
		public async Task<ActionResult> Details(int id)
		{
			var cliente = await _appBase.GetById(id);
			var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

			return View(clienteViewModel);
		}

		// GET: Clientes/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Clientes/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ClienteViewModel cliente)
		{
			if (ModelState.IsValid)
			{
				var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
				_appBase.Add(clienteDomain);

				return RedirectToAction("index");
			}

			return View(cliente);
		}

		// GET: Clientes/Edit/5
		public async Task<ActionResult> Editar(int id)
		{
			var cliente = await _appBase.GetById(id);
			var ClienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

			return View(ClienteViewModel);
		}

		// POST: Clientes/Edit/5   
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Editar(ClienteViewModel cliente)
		{
			if (ModelState.IsValid)
			{
				var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
				_appBase.Update(clienteDomain);

				return RedirectToAction("index");
			}

			return View(cliente);
		}

		// GET: Clientes/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			var cliente = await _appBase.GetById(id);
			var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

			return View(clienteViewModel);
		}

		//POST: Clientes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var cliente = await _appBase.GetById(id);
			_appBase.Remove(cliente);

			return RedirectToAction("Index");
		}

		public async Task<ActionResult> ProdutosPorCliente(int clienteId)
		{			
			IEnumerable<Produto> produtos = (await _produtoApp.GetAll()).Where(x => x.ClienteId == clienteId);

			var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtos);
			return View(produtoViewModel);
		}
	}
}
