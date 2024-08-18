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
    public class ConfiguracoesController : Controller
    {
        private readonly IConfiguracaoNFAppService _configuracaoNFApp;
        private readonly IDocumentoNotaFiscalAppService _documentoNFApp;
        private readonly INaturezaOperacaoAppService _naturezaOperacaoApp;
        private readonly IContabilidadeAppService _contabilidadeApp;
       
        public ConfiguracoesController(IConfiguracaoNFAppService configuracaoNFApp,
            IDocumentoNotaFiscalAppService documentoNFApp,
            INaturezaOperacaoAppService naturezaOperacaoApp,
            IContabilidadeAppService contabilidadeApp)
        {
            _configuracaoNFApp = configuracaoNFApp;
            _documentoNFApp = documentoNFApp;
            _naturezaOperacaoApp = naturezaOperacaoApp;
            _contabilidadeApp = contabilidadeApp;
        }
    
        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            IEnumerable<ConfiguracaoNF> configuracoes = await _configuracaoNFApp.GetAll();

            foreach (var item in configuracoes)
            {
                item.DocumentoNotaFiscal = await _documentoNFApp.GetById(item.DocumentoNotaFiscalId);
                item.NaturezaOperacao = await _naturezaOperacaoApp.GetById(item.NaturezaOperacaoId);
                item.Contabilidade = await _contabilidadeApp.GetById(item.ContabilidadeId);
            }

            var configuracoesViewModel = Mapper.Map<IEnumerable<ConfiguracaoNF>, IEnumerable<ConfiguracaoViewModel>>(configuracoes);
            return View(configuracoesViewModel);
        }

        //public async Task<ActionResult> Especiais()
        //{
        //    var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(await _clienteApp.ObterClientesEspeciais());
        //    return View(clienteViewModel);
        //}

        //GET: Empresas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var configuracao = await _configuracaoNFApp.GetById(id);

            configuracao.Contabilidade = await _contabilidadeApp.GetById(configuracao.ContabilidadeId);
            configuracao.DocumentoNotaFiscal = await _documentoNFApp.GetById(configuracao.DocumentoNotaFiscalId);
            configuracao.NaturezaOperacao = await _naturezaOperacaoApp.GetById(configuracao.NaturezaOperacaoId);

            var configuracaoViewModel = Mapper.Map<ConfiguracaoNF, ConfiguracaoViewModel>(configuracao);           

            return View(configuracaoViewModel);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConfiguracaoViewModel configuracaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var configuracaoDomain = Mapper.Map<ConfiguracaoViewModel, ConfiguracaoNF>(configuracaoViewModel);
                _configuracaoNFApp.Add(configuracaoDomain);

                return RedirectToAction("index");
            }

            return View(configuracaoViewModel);
        }

        // GET: Empresas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var configuracao = await _configuracaoNFApp.GetById(id);

            configuracao.DocumentoNotaFiscal = await _documentoNFApp.GetById(configuracao.DocumentoNotaFiscalId);

            var configuracaoViewModel = Mapper.Map<ConfiguracaoNF, ConfiguracaoViewModel>(configuracao);
           
            //preenche dropdown
            ViewBag.ContabilidadeId = new SelectList(await _contabilidadeApp.GetAll(), "ContabilidadeId", "RazaoSocialContabilidade", configuracao.ContabilidadeId);
            ViewBag.NaturezaOperacaoId = new SelectList(await _naturezaOperacaoApp.GetAll(), "NaturezaOperacaoId", "Descricao", configuracao.NaturezaOperacaoId);

            return View(configuracaoViewModel);
        }

        // POST: Empresas/Edit/5   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConfiguracaoViewModel configuracaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var configuracaoDomain = Mapper.Map<ConfiguracaoViewModel, ConfiguracaoNF>(configuracaoViewModel);
                _configuracaoNFApp.Update(configuracaoDomain);

                return RedirectToAction("index");
            }

            return View(configuracaoViewModel);
        }

        //// GET: Empresas/Delete/5
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var empresa = await _empresaApp.GetById(id);
        //    var empresaViewModel = Mapper.Map<Empresa, EmpresaViewModel>(empresa);

        //    return View(empresaViewModel);
        //}

        ////POST: Empresas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    var empresa = await _empresaApp.GetById(id);
        //    await _empresaApp.Remove(empresa);

        //    return RedirectToAction("Index");
        //}
    }
}