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
    public class DestinatariosPessoaJuridicaController : Controller
    {
        private readonly IEnderecoPessoaAppService _enderecoPessoaApp;
        private readonly IPessoaAppService _pessoaApp;
        private readonly ITipoEnderecoPessoaAppService _tipoEnderecoPessoaApp;
        private readonly IPessoaJuridicaAppService _pessoaJuridicaApp;
        private readonly IIndicadorIEAppService _indicadorIEApp;

        public DestinatariosPessoaJuridicaController(IEnderecoPessoaAppService enderecoPessoaApp, IPessoaAppService pessoaApp, ITipoEnderecoPessoaAppService tipoEnderecoPessoaApp, IPessoaJuridicaAppService pessoaJuridicaApp, IIndicadorIEAppService indicadorIEApp)
        {
            _enderecoPessoaApp = enderecoPessoaApp;
            _pessoaApp = pessoaApp;
            _tipoEnderecoPessoaApp = tipoEnderecoPessoaApp;
            _pessoaJuridicaApp = pessoaJuridicaApp;
            _indicadorIEApp = indicadorIEApp;
        }

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            IEnumerable<PessoaJuridica> pessoasJuridicas = await _pessoaJuridicaApp.GetAll();

            IEnumerable<EnderecoPessoa> enderecoPessoa = await _enderecoPessoaApp.GetAll();
            IEnumerable<TipoEnderecoPessoa> tipoEnderecoPessoa = await _tipoEnderecoPessoaApp.GetAll();

            foreach (var item in pessoasJuridicas)
            {
                item.Pessoa = await _pessoaApp.GetById(item.PessoaId);
                item.EnderecoPessoa = enderecoPessoa.Where(x => x.PessoaId == item.PessoaId).FirstOrDefault();                               
                item.EnderecoPessoa.TipoEnderecoPessoa = tipoEnderecoPessoa.Where(x => x.TipoEnderecoPessoaId == item.EnderecoPessoa.TipoEnderecoPessoaId).FirstOrDefault();
                item.IndicadorIE = (await _indicadorIEApp.GetAll()).Where(x => x.IndicadorIEId == item.IndicadorIEId).FirstOrDefault();
                //item.CFOPs = await _CFOPApp.BuscarPorTipoGrupoImpostosId(item.TipoGrupoImpostosId);                                
            }

            var pessoaJuridicaViewModel = Mapper.Map<IEnumerable<PessoaJuridica>, IEnumerable<PessoaJuridicaViewModel>>(pessoasJuridicas);
            return View(pessoaJuridicaViewModel);
        }

        //public async Task<ActionResult> Especiais()
        //{
        //    var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(await _clienteApp.ObterClientesEspeciais());
        //    return View(clienteViewModel);
        //}

        //GET: Empresas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var pj = await _pessoaJuridicaApp.GetById(id);

            pj.Pessoa = await _pessoaApp.GetById(pj.PessoaId);
            pj.EnderecoPessoa = (await _enderecoPessoaApp.GetAll()).Where(x => x.PessoaId == pj.PessoaId).FirstOrDefault();
            pj.EnderecoPessoa.TipoEnderecoPessoa = await _tipoEnderecoPessoaApp.GetById(pj.EnderecoPessoa.TipoEnderecoPessoaId);
            pj.IndicadorIE = (await _indicadorIEApp.GetAll()).Where(x => x.IndicadorIEId == pj.IndicadorIEId).FirstOrDefault();
            var pjModel = Mapper.Map<PessoaJuridica, PessoaJuridicaViewModel>(pj);

            return View(pjModel);
        }

        //GET: Empresas/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.TipoEnderecoPessoaId = new SelectList(await _tipoEnderecoPessoaApp.GetAll(), "TipoEnderecoPessoaId", "Tipo");
            ViewBag.IndicadorIEId = new SelectList(await _indicadorIEApp.GetAll(), "IndicadorIEId", "Descricao");

            return View();
        }

        //POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PessoaJuridicaViewModel pessoaJuridicaViewModel)
        {

            if (ModelState.IsValid)
            {
                /* Insere o registro da Pessoa */
                var pessoaDomain = Mapper.Map<PessoaViewModel, Pessoa>(pessoaJuridicaViewModel.Pessoa);
                int pessoaId = await _pessoaApp.Add(pessoaDomain);

                pessoaJuridicaViewModel.PessoaId = pessoaId;
                pessoaJuridicaViewModel.EnderecoPessoa.PessoaId = pessoaId;
                pessoaJuridicaViewModel.EnderecoPessoa.TipoEnderecoPessoaId = pessoaJuridicaViewModel.TipoEnderecoPessoaId;

                /* Insere o registro do Endereço da pessoa jurídica */
                var enderecoPessoaDomain = Mapper.Map<EnderecoPessoaViewModel, EnderecoPessoa>(pessoaJuridicaViewModel.EnderecoPessoa);
                pessoaJuridicaViewModel.EnderecoPessoa.EnderecoPessoaId = await _enderecoPessoaApp.Add(enderecoPessoaDomain);

                /* Insere o registro da Pessoa Jurídica */
                var pessoaJuridicaDomain = Mapper.Map<PessoaJuridicaViewModel, PessoaJuridica>(pessoaJuridicaViewModel);
                pessoaJuridicaViewModel.PessoaJuridicaId = await _pessoaJuridicaApp.Add(pessoaJuridicaDomain);

                return RedirectToAction("index");
            }
            ViewBag.TipoEnderecoPessoaId = new SelectList(await _tipoEnderecoPessoaApp.GetAll(), "TipoEnderecoPessoaId", "Tipo", pessoaJuridicaViewModel.TipoEnderecoPessoaId);
            ViewBag.IndicadorIEId = new SelectList(await _tipoEnderecoPessoaApp.GetAll(), "IndicadorIEId", "Descricao", pessoaJuridicaViewModel.IndicadorIEId);

            return View(pessoaJuridicaViewModel);
        }
        //[HttpGet]
        //public async Task<JsonResult> GetDropdownList(int? value)
        //{
        //    if (value == 2)
        //    {
        //        var Tipos = await _tipoServicoApp.GetAll();
        //        ViewBag.TipoServicoId = new SelectList(Tipos, "TipoServicoId", "Descricao");

        //        return Json(new { data = Tipos }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //GET: Destinatarios/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var pessoaJuridica = await _pessoaJuridicaApp.GetById(id);

            pessoaJuridica.Pessoa = await _pessoaApp.GetById(pessoaJuridica.PessoaId);
            pessoaJuridica.EnderecoPessoa = (await _enderecoPessoaApp.GetAll()).Where(x => x.PessoaId == pessoaJuridica.PessoaId).FirstOrDefault();           

            var pessoaJuridicaViewModel = Mapper.Map<PessoaJuridica, PessoaJuridicaViewModel>(pessoaJuridica);

            int tipoEnderecoPessoaId = (pessoaJuridica.EnderecoPessoa == null) ? 0 : pessoaJuridica.EnderecoPessoa.TipoEnderecoPessoaId;
            
            //preenche dropdown
            ViewBag.IndicadorIEId = new SelectList(await _indicadorIEApp.GetAll(), "IndicadorIEId", "Descricao", pessoaJuridica.IndicadorIEId);
            ViewBag.TipoEnderecoPessoaId = new SelectList(await _tipoEnderecoPessoaApp.GetAll(), "TipoEnderecoPessoaId", "Tipo", tipoEnderecoPessoaId);

            return View(pessoaJuridicaViewModel);
        }

        //// POST: Empresas/Edit/5   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PessoaJuridicaViewModel pessoaJuridicaViewModel)
        {
            pessoaJuridicaViewModel.EnderecoPessoa.TipoEnderecoPessoaId = pessoaJuridicaViewModel.TipoEnderecoPessoaId;
            pessoaJuridicaViewModel.EnderecoPessoa.PessoaId = pessoaJuridicaViewModel.PessoaId;
            pessoaJuridicaViewModel.Pessoa.PessoaId = pessoaJuridicaViewModel.PessoaId;

            if (pessoaJuridicaViewModel.EnderecoPessoa.EnderecoPessoaId == 0) // Insere Endereço se não existir registro 
            {
                var enderecoPessoaDomain = Mapper.Map<EnderecoPessoaViewModel, EnderecoPessoa>(pessoaJuridicaViewModel.EnderecoPessoa);
                pessoaJuridicaViewModel.EnderecoPessoa.EnderecoPessoaId = await _enderecoPessoaApp.Add(enderecoPessoaDomain);
            }

            if (ModelState.IsValid)
            {
                var pessoaDomain = Mapper.Map<PessoaViewModel, Pessoa>(pessoaJuridicaViewModel.Pessoa);
                await _pessoaApp.Update(pessoaDomain);

                var enderecoPessoaDomain = Mapper.Map<EnderecoPessoaViewModel, EnderecoPessoa>(pessoaJuridicaViewModel.EnderecoPessoa);
                await _enderecoPessoaApp.Update(enderecoPessoaDomain);// Altera o registro do Endereço da pessoa jurídica

                var pessoaJuridicaDomain = Mapper.Map<PessoaJuridicaViewModel, PessoaJuridica>(pessoaJuridicaViewModel);
                await _pessoaJuridicaApp.Update(pessoaJuridicaDomain);

                return RedirectToAction("index");
            }

            int tipoEnderecoPessoaId = (pessoaJuridicaViewModel.EnderecoPessoa == null) ? 0 : pessoaJuridicaViewModel.EnderecoPessoa.TipoEnderecoPessoaId;
            ViewBag.IndicadorIEId = new SelectList(await _indicadorIEApp.GetAll(), "IndicadorIEId", "Descricao", pessoaJuridicaViewModel.IndicadorIEId);
            ViewBag.TipoEnderecoPessoaId = new SelectList(await _tipoEnderecoPessoaApp.GetAll(), "TipoEnderecoPessoaId", "Tipo", tipoEnderecoPessoaId);

            return View(pessoaJuridicaViewModel);
        }

        // GET: Empresas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var pj = await _pessoaJuridicaApp.GetById(id);
            var pessoaJuridicaViewModel = Mapper.Map<PessoaJuridica, PessoaJuridicaViewModel>(pj);

            return View(pessoaJuridicaViewModel);
        }

        //POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var pj = await _pessoaJuridicaApp.GetById(id);

            var epf = (await _enderecoPessoaApp.GetAll()).Where(x => x.PessoaId == pj.PessoaId).FirstOrDefault();
            if (epf != null)
                await _enderecoPessoaApp.Remove(epf);

            await _pessoaJuridicaApp.Remove(pj);

            var pessoa = (await _pessoaApp.GetAll()).Where(x => x.PessoaId == pj.PessoaId).FirstOrDefault();
            if (pessoa != null)
                await _pessoaApp.Remove(pessoa);

            return RedirectToAction("Index");
        }
    }
}