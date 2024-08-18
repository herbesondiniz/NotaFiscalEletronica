using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IEmpresaAppService _empresaApp;
        private readonly IRegimeTributarioAppService _regimeTributarioApp;
        public EmpresasController(IEmpresaAppService empresaApp, IRegimeTributarioAppService regimeTributarioApp)
        {
            _empresaApp = empresaApp;
            _regimeTributarioApp = regimeTributarioApp;
        }
        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            IEnumerable<Empresa> empresas = await _empresaApp.GetAll();

            foreach (var item in empresas)
            {
                item.RegimeTributario = await _regimeTributarioApp.GetById(item.RegimeTributarioId);
            }

            var empresaViewModel = Mapper.Map<IEnumerable<Empresa>, IEnumerable<EmpresaViewModel>>(empresas);
            return View(empresaViewModel);
        }

        //public async Task<ActionResult> Especiais()
        //{
        //    var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(await _clienteApp.ObterClientesEspeciais());
        //    return View(clienteViewModel);
        //}

        // GET: Empresas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var empresa = await _empresaApp.GetById(id);
            var empresaViewModel = Mapper.Map<Empresa, EmpresaViewModel>(empresa);

            return View(empresaViewModel);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel empresa)
        {
            if (ModelState.IsValid)
            {
                var empresaDomain = Mapper.Map<EmpresaViewModel, Empresa>(empresa);
                _empresaApp.Add(empresaDomain);

                return RedirectToAction("index");
            }

            return View(empresa);
        }

        //// GET: Empresas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var empresa = await _empresaApp.GetById(id);
            var EmpresaViewModel = Mapper.Map<Empresa, EmpresaViewModel>(empresa);

            return View(EmpresaViewModel);
        }

        //// POST: Empresas/Edit/5   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpresaViewModel empresa)
        {
            if (ModelState.IsValid)
            {
                var empresaDomain = Mapper.Map<EmpresaViewModel, Empresa>(empresa);
                _empresaApp.Update(empresaDomain);

                return RedirectToAction("index");
            }

            return View(empresa);
        }

        //// GET: Empresas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var empresa = await _empresaApp.GetById(id);
            var empresaViewModel = Mapper.Map<Empresa, EmpresaViewModel>(empresa);

            return View(empresaViewModel);
        }

        ////POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _empresaApp.GetById(id);
            await _empresaApp.Remove(empresa);

            return RedirectToAction("Index");
        }

        //public async Task<ActionResult> ProdutosPorCliente(int clienteId)
        //{
        //    IEnumerable<Produto> produtos = (await _produtoApp.GetAll()).Where(x => x.ClienteId == clienteId);

        //    var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtos);
        //    return View(produtoViewModel);
        //}
    }
}