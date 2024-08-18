using AutoMapper;
using ProjetoModeloDDD.Application;
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
    public class GrupoImpostosController : Controller
    {
        private readonly IGrupoImpostosAppService _grupoImpostosApp;
        private readonly ITipoGrupoImpostosAppService _tipoGrupoImpostosApp;
        private readonly ICFOPAppService _CFOPApp;
        private readonly ITipoServicoAppService _tipoServicoApp;

        public GrupoImpostosController(IGrupoImpostosAppService grupoImpostosApp, ITipoGrupoImpostosAppService tipoGrupoImpostosApp, ICFOPAppService CFOPApp, ITipoServicoAppService tipoServicoApp)
        {
            _grupoImpostosApp = grupoImpostosApp;
            _tipoGrupoImpostosApp = tipoGrupoImpostosApp;
            _CFOPApp = CFOPApp;
            _tipoServicoApp = tipoServicoApp;
        }

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            IEnumerable<GrupoImpostos> grupos = await _grupoImpostosApp.GetAll();
            IEnumerable<CFOP> cfops = await _CFOPApp.GetAll();
            foreach (var item in grupos)
            {
                item.TipoGrupoImpostos = await _tipoGrupoImpostosApp.GetById(item.TipoGrupoImpostosId);
                item.CFOPs = cfops.Where(x=>x.TipoGrupoImpostosId == item.TipoGrupoImpostosId);
                //item.CFOPs = await _CFOPApp.BuscarPorTipoGrupoImpostosId(item.TipoGrupoImpostosId);                
                item.TipoServico = item.TipoServicoId == 0 ? null : await _tipoServicoApp.GetById(item.TipoServicoId);

            }

            var grupoImpostoViewModel = Mapper.Map<IEnumerable<GrupoImpostos>, IEnumerable<GrupoImpostosViewModel>>(grupos);
            return View(grupoImpostoViewModel);
        }

        //public async Task<ActionResult> Especiais()
        //{
        //    var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(await _clienteApp.ObterClientesEspeciais());
        //    return View(clienteViewModel);
        //}

        //GET: Empresas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var grupo = await _grupoImpostosApp.GetById(id);

            grupo.TipoGrupoImpostos = await _tipoGrupoImpostosApp.GetById(grupo.TipoGrupoImpostosId);
            grupo.CFOPs = await _CFOPApp.BuscarPorTipoGrupoImpostosId(grupo.TipoGrupoImpostosId);
            grupo.TipoServico = grupo.TipoServicoId == 0 ? null : await _tipoServicoApp.GetById(grupo.TipoServicoId);

            var grupoViewModel = Mapper.Map<GrupoImpostos, GrupoImpostosViewModel>(grupo);

            return View(grupoViewModel);
        }

        //GET: Empresas/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.TipoGrupoImpostosId = new SelectList(await _tipoGrupoImpostosApp.GetAll(), "TipoGrupoImpostosId", "Descricao");
            ViewBag.TipoServicoId = new SelectList("", "", "");

            return View();
        }

        //POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GrupoImpostosViewModel grupoImpostos)
        {
            if (ModelState.IsValid)
            {
                var grupoImpostosDomain = Mapper.Map<GrupoImpostosViewModel, GrupoImpostos>(grupoImpostos);
                _grupoImpostosApp.Add(grupoImpostosDomain);

                return RedirectToAction("index");
            }

            ViewBag.TipoGrupoImpostosId = new SelectList(await _tipoGrupoImpostosApp.GetAll(), "TipoGrupoImpostosId", "Descricao", grupoImpostos.TipoGrupoImpostosId);            
            ViewBag.TipoServicoId = new SelectList("", "", "");

            return View(grupoImpostos);
        }
        [HttpGet]
        public async Task<JsonResult> GetDropdownList(int? value)
        {            
            if (value == 2)
            {
                var Tipos = await _tipoServicoApp.GetAll();                
                ViewBag.TipoServicoId = new SelectList(Tipos, "TipoServicoId", "Descricao");

                return Json(new { data = Tipos }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        //GET: Empresas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var grupoImpostos = await _grupoImpostosApp.GetById(id);

            grupoImpostos.TipoGrupoImpostos = await _tipoGrupoImpostosApp.GetById(grupoImpostos.TipoGrupoImpostosId);
            grupoImpostos.CFOPs = await _CFOPApp.BuscarPorTipoGrupoImpostosId(grupoImpostos.TipoGrupoImpostosId);
            grupoImpostos.TipoServico = grupoImpostos.TipoServicoId == 0 ? null : await _tipoServicoApp.GetById(grupoImpostos.TipoServicoId);            

            var grupoImpostosViewModel = Mapper.Map<GrupoImpostos, GrupoImpostosViewModel>(grupoImpostos);

            //preenche dropdown
            ViewBag.TipoGrupoImpostosId = new SelectList(await _tipoGrupoImpostosApp.GetAll(), "TipoGrupoImpostosId", "Descricao", grupoImpostos.TipoGrupoImpostosId);

            ViewBag.TipoServicoId = new SelectList("", "", "");
            
            if (grupoImpostos.TipoServicoId > 0) 
            {
                ViewBag.TipoServicoId = new SelectList(await _tipoServicoApp.GetAll(), "TipoServicoId", "Descricao", grupoImpostos.TipoServicoId);
            }         
            
            return View(grupoImpostosViewModel);
        }

        //// POST: Empresas/Edit/5   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GrupoImpostosViewModel grupoImpostosViewModel)
        {
            if (ModelState.IsValid)
            {               
                if (grupoImpostosViewModel.TipoGrupoImpostosId == 1) 
                {
                    grupoImpostosViewModel.TipoServicoId = 0;
                }
                var grupoImpostosDomain = Mapper.Map<GrupoImpostosViewModel, GrupoImpostos>(grupoImpostosViewModel);
                _grupoImpostosApp.Update(grupoImpostosDomain);

                return RedirectToAction("index");
            }

            return View(grupoImpostosViewModel);
        }

        //// GET: Empresas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var grupo = await _grupoImpostosApp.GetById(id);
            var GrupoImpostosViewModel = Mapper.Map<GrupoImpostos, GrupoImpostosViewModel>(grupo);

            return View(GrupoImpostosViewModel);
        }

        //POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _grupoImpostosApp.GetById(id);
            await _grupoImpostosApp.Remove(grupo);

            return RedirectToAction("Index");
        }
    }
}