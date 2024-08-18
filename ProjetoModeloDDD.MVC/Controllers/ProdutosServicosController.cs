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
    public class ProdutosServicosController : Controller
    {
        private readonly IGrupoImpostosAppService _grupoImpostosApp;
        private readonly IUnidadeComercialAppService _unidadeComercialApp;
        private readonly INCMAppService _ncmApp;
        private readonly IProdutoServicoAppService _produtoServicoApp;

        public ProdutosServicosController(IUnidadeComercialAppService unidadeComercialApp,
            INCMAppService ncmApp,
            IProdutoServicoAppService produtoServicoApp,
            IGrupoImpostosAppService grupoImpostosApp)
        {
            _grupoImpostosApp = grupoImpostosApp;
            _unidadeComercialApp = unidadeComercialApp;
            _ncmApp = ncmApp;
            _produtoServicoApp = produtoServicoApp;
        }

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            IEnumerable<ProdutoServico> produtosServicos = await _produtoServicoApp.GetAll();

            foreach (var item in produtosServicos)
            {
                item.GrupoImpostos = await _grupoImpostosApp.GetById(item.GrupoImpostosId);
                item.UnidadeComercial = await _unidadeComercialApp.GetById(item.UnidadeComercialId);
                item.NCM = item.NCMId == 0 ? null : await _ncmApp.GetById(item.NCMId);
            }

            var produtosServicosViewModel = Mapper.Map<IEnumerable<ProdutoServico>, IEnumerable<ProdutoServicoViewModel>>(produtosServicos);
            return View(produtosServicosViewModel);
        }

        //GET: Empresas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var produto = await _produtoServicoApp.GetById(id);

            produto.GrupoImpostos = await _grupoImpostosApp.GetById(produto.GrupoImpostosId);
            produto.UnidadeComercial = await _unidadeComercialApp.GetById(produto.UnidadeComercialId);            
            produto.NCM = produto.NCMId == 0 ? null : await _ncmApp.GetById(produto.NCMId);            

            var produtoServicoViewModel = Mapper.Map<ProdutoServico, ProdutoServicoViewModel>(produto);

            return View(produtoServicoViewModel);
        }

        // GET: Empresas/Create
        public async Task<ActionResult> Create()
        {            
            ViewBag.GrupoImpostosId = new SelectList(await _grupoImpostosApp.GetAll(), "GrupoImpostosId", "Descricao");
            ViewBag.UnidadeComercialId = new SelectList(await _unidadeComercialApp.GetAll(), "UnidadeComercialId", "Unidade");
            return View();
        }

        //POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoServicoViewModel produtoServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produtoServicoDomain = Mapper.Map<ProdutoServicoViewModel, ProdutoServico>(produtoServicoViewModel);
                _produtoServicoApp.Add(produtoServicoDomain);

                return RedirectToAction("index");
            }

            ViewBag.GrupoImpostosId = new SelectList(await _grupoImpostosApp.GetAll(), "GrupoImpostosId", "Descricao", produtoServicoViewModel.GrupoImpostosId);

            return View(produtoServicoViewModel);
        }

        // GET: Empresas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var produtoServico = await _produtoServicoApp.GetById(id);

            produtoServico.GrupoImpostos = await _grupoImpostosApp.GetById(produtoServico.GrupoImpostosId);
            produtoServico.UnidadeComercial = await _unidadeComercialApp.GetById(produtoServico.UnidadeComercialId);
            produtoServico.NCM = produtoServico.NCMId == 0 ? null : await _ncmApp.GetById(produtoServico.NCMId);

            var produtoServicoViewModel = Mapper.Map<ProdutoServico, ProdutoServicoViewModel>(produtoServico);

            //preenche dropdown
            ViewBag.GrupoImpostosId = new SelectList(await _grupoImpostosApp.GetAll(), "GrupoImpostosId", "Descricao", produtoServico.GrupoImpostosId);
            ViewBag.UnidadeComercialId = new SelectList(await _unidadeComercialApp.GetAll(), "UnidadeComercialId", "Unidade", produtoServico.UnidadeComercialId);
            //ViewBag.NCMId = new SelectList(await _ncmApp.GetAll(), "NCMId", "CodigoNCM", produtoServico.NCMId);

            return View(produtoServicoViewModel);
        }

        // POST: Empresas/Edit/5   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoServicoViewModel produtoServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produtoServicoDomain = Mapper.Map<ProdutoServicoViewModel, ProdutoServico>(produtoServicoViewModel);
                _produtoServicoApp.Update(produtoServicoDomain);

                return RedirectToAction("index");
            }

            ViewBag.GrupoImpostosId = new SelectList(await _grupoImpostosApp.GetAll(), "GrupoImpostosId", "Descricao", produtoServicoViewModel.GrupoImpostosId);
            ViewBag.UnidadeComercialId = new SelectList(await _unidadeComercialApp.GetAll(), "UnidadeComercialId", "Unidade", produtoServicoViewModel.UnidadeComercialId);

            return View(produtoServicoViewModel);
        }

        //// GET: Empresas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var produtoServico = await _produtoServicoApp.GetById(id);
            var produtoServicoViewModel = Mapper.Map<ProdutoServico, ProdutoServicoViewModel>(produtoServico);

            return View(produtoServicoViewModel);
        }

        ////POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var produtoServico = await _produtoServicoApp.GetById(id);
            await _produtoServicoApp.Remove(produtoServico);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> GetNCMId(string value)
        {            
            var nCM = await _ncmApp.BuscarPorCodigoNCM(value);
            var nCMId = 0;
            
            if (nCM.ToList().Count > 0)
                nCMId = nCM.FirstOrDefault().NCMId;

            return Json(new { data = nCMId }, JsonRequestBehavior.AllowGet);
        }
    }
}