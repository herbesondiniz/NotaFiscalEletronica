using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class DestinatariosPessoaFisicaController : Controller
    {
        private readonly IEnderecoPessoaAppService _enderecoPessoaApp;
        private readonly IPessoaAppService _pessoaApp;
        private readonly ITipoEnderecoPessoaAppService _tipoEnderecoPessoaApp;
        private readonly IAppServiceBase<PessoaFisica> _pessoaFisicaApp;

        public DestinatariosPessoaFisicaController(IEnderecoPessoaAppService enderecoPessoaApp, IPessoaAppService pessoaApp, ITipoEnderecoPessoaAppService tipoEnderecoPessoaApp, IAppServiceBase<PessoaFisica> pessoaFisicaApp)
        {
            _enderecoPessoaApp = enderecoPessoaApp;
            _pessoaApp = pessoaApp;
            _tipoEnderecoPessoaApp = tipoEnderecoPessoaApp;
            _pessoaFisicaApp = pessoaFisicaApp;
        }

        
        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            IEnumerable<PessoaFisica> pessoasfisicas = await _pessoaFisicaApp.GetAll();

            IEnumerable<EnderecoPessoa> enderecoPessoa = await _enderecoPessoaApp.GetAll();
            IEnumerable<TipoEnderecoPessoa> tipoEnderecoPessoa = await _tipoEnderecoPessoaApp.GetAll();

            foreach (var item in pessoasfisicas)
            {
                item.Pessoa = await _pessoaApp.GetById(item.PessoaId);
                //item.EnderecoPessoa = enderecoPessoa.Where(x => x.PessoaId == item.PessoaId).FirstOrDefault();               
                //item.EnderecoPessoa.Endereco = endereco.Where(x => x.EnderecoId == item.EnderecoPessoa.EnderecoId).FirstOrDefault();
                //item.EnderecoPessoa.TipoEnderecoPessoa = tipoEnderecoPessoa.Where(x => x.TipoEnderecoPessoaId == item.EnderecoPessoa.TipoEnderecoPessoaId).FirstOrDefault();
                //item.CFOPs = await _CFOPApp.BuscarPorTipoGrupoImpostosId(item.TipoGrupoImpostosId);                                
            }

            var PessoaFisicaViewModel = Mapper.Map<IEnumerable<PessoaFisica>, IEnumerable<PessoaFisicaViewModel>>(pessoasfisicas);
            return View(PessoaFisicaViewModel);
        }

        //public async Task<ActionResult> Especiais()
        //{
        //    var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(await _clienteApp.ObterClientesEspeciais());
        //    return View(clienteViewModel);
        //}

        //GET: Empresas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var pf = await _pessoaFisicaApp.GetById(id);

            pf.Pessoa = await _pessoaApp.GetById(pf.PessoaId);
            pf.EnderecoPessoa = (await _enderecoPessoaApp.GetAll()).Where(x=>x.PessoaId == pf.PessoaId).FirstOrDefault();
            pf.EnderecoPessoa.TipoEnderecoPessoa = await _tipoEnderecoPessoaApp.GetById(pf.EnderecoPessoa.TipoEnderecoPessoaId);
            var pfModel = Mapper.Map<PessoaFisica, PessoaFisicaViewModel>(pf);
            
            return View(pfModel);
        }

        //GET: Empresas/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.TipoEnderecoPessoaId = new SelectList(await _tipoEnderecoPessoaApp.GetAll(), "TipoEnderecoPessoaId", "Tipo");

            return View();
        }

        //POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PessoaFisicaViewModel pessoaFisicaViewModel)
        {

            if (ModelState.IsValid)
            {
                /* Insere o registro da Pessoa */
                var pessoaDomain = Mapper.Map<PessoaViewModel, Pessoa>(pessoaFisicaViewModel.Pessoa);
                int pessoaId = await _pessoaApp.Add(pessoaDomain);

                pessoaFisicaViewModel.PessoaId = pessoaId;
                pessoaFisicaViewModel.EnderecoPessoa.PessoaId = pessoaId;
                pessoaFisicaViewModel.EnderecoPessoa.TipoEnderecoPessoaId = pessoaFisicaViewModel.TipoEnderecoPessoaId;

                /* Insere o registro do Endereço da pessoa física */
                var enderecoPessoaDomain = Mapper.Map<EnderecoPessoaViewModel, EnderecoPessoa>(pessoaFisicaViewModel.EnderecoPessoa);
                pessoaFisicaViewModel.EnderecoPessoa.EnderecoPessoaId = await _enderecoPessoaApp.Add(enderecoPessoaDomain);

                /* Insere o registro da Pessoa Física */
                var pessoaFisicaDomain = Mapper.Map<PessoaFisicaViewModel, PessoaFisica>(pessoaFisicaViewModel);
                pessoaFisicaViewModel.PessoaFisicaId = await _pessoaFisicaApp.Add(pessoaFisicaDomain);

                return RedirectToAction("index");
            }

            ViewBag.TipoEnderecoPessoaId = new SelectList(await _tipoEnderecoPessoaApp.GetAll(), "TipoEnderecoPessoaId", "Tipo", pessoaFisicaViewModel.TipoEnderecoPessoaId);

            return View(pessoaFisicaViewModel);
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
            var pessoaFisica = await _pessoaFisicaApp.GetById(id);

            pessoaFisica.Pessoa = await _pessoaApp.GetById(pessoaFisica.PessoaId);
            pessoaFisica.EnderecoPessoa = (await _enderecoPessoaApp.GetAll()).Where(x => x.PessoaId == pessoaFisica.PessoaId).FirstOrDefault();

            var pessoaFisicaViewModel = Mapper.Map<PessoaFisica, PessoaFisicaViewModel>(pessoaFisica);

            int tipoEnderecoPessoaId = (pessoaFisica.EnderecoPessoa == null) ? 0 : pessoaFisica.EnderecoPessoa.TipoEnderecoPessoaId;
            //preenche dropdown
            ViewBag.TipoEnderecoPessoaId = new SelectList(await _tipoEnderecoPessoaApp.GetAll(), "TipoEnderecoPessoaId", "Tipo", tipoEnderecoPessoaId);

            return View(pessoaFisicaViewModel);
        }

        //// POST: Empresas/Edit/5   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PessoaFisicaViewModel pessoaFisicaViewModel)
        {
            pessoaFisicaViewModel.EnderecoPessoa.TipoEnderecoPessoaId = pessoaFisicaViewModel.TipoEnderecoPessoaId;
            pessoaFisicaViewModel.EnderecoPessoa.PessoaId = pessoaFisicaViewModel.PessoaId;
            pessoaFisicaViewModel.Pessoa.PessoaId = pessoaFisicaViewModel.PessoaId;

            if (pessoaFisicaViewModel.EnderecoPessoa.EnderecoPessoaId == 0) // Insere Endereço se não existir registro 
            {
                var enderecoPessoaDomain = Mapper.Map<EnderecoPessoaViewModel, EnderecoPessoa>(pessoaFisicaViewModel.EnderecoPessoa);                
                pessoaFisicaViewModel.EnderecoPessoa.EnderecoPessoaId = await _enderecoPessoaApp.Add(enderecoPessoaDomain);
            }

            if (ModelState.IsValid)
            {
                var pessoaDomain = Mapper.Map<PessoaViewModel, Pessoa>(pessoaFisicaViewModel.Pessoa);
                await _pessoaApp.Update(pessoaDomain);

                var enderecoPessoaDomain = Mapper.Map<EnderecoPessoaViewModel, EnderecoPessoa>(pessoaFisicaViewModel.EnderecoPessoa);               
                await _enderecoPessoaApp.Update(enderecoPessoaDomain);// Altera o registro do Endereço da pessoa física 

                var pessoaFisicaDomain = Mapper.Map<PessoaFisicaViewModel, PessoaFisica>(pessoaFisicaViewModel);
                await _pessoaFisicaApp.Update(pessoaFisicaDomain);

                return RedirectToAction("index");
            }

            int tipoEnderecoPessoaId = (pessoaFisicaViewModel.EnderecoPessoa == null) ? 0 : pessoaFisicaViewModel.EnderecoPessoa.TipoEnderecoPessoaId;
            ViewBag.TipoEnderecoPessoaId = new SelectList(await _tipoEnderecoPessoaApp.GetAll(), "TipoEnderecoPessoaId", "Tipo", tipoEnderecoPessoaId);

            return View(pessoaFisicaViewModel);
        }

        // GET: Empresas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var pf = await _pessoaFisicaApp.GetById(id);
            var PessoaFisicaViewModel = Mapper.Map<PessoaFisica, PessoaFisicaViewModel>(pf);

            return View(PessoaFisicaViewModel);
        }

        //POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var pf = await _pessoaFisicaApp.GetById(id);

            var epf = (await _enderecoPessoaApp.GetAll()).Where(x => x.PessoaId == pf.PessoaId).FirstOrDefault();
            if(epf != null)
                await _enderecoPessoaApp.Remove(epf);
                      
            await _pessoaFisicaApp.Remove(pf);

            var pessoa = (await _pessoaApp.GetAll()).Where(x=>x.PessoaId == pf.PessoaId).FirstOrDefault();
            if(pessoa != null)
                await _pessoaApp.Remove(pessoa);

            return RedirectToAction("Index");
        }
    }
}