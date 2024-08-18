[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjetoModeloDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjetoModeloDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ProjetoModeloDDD.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using ProjetoModeloDDD.Application;
    using ProjetoModeloDDD.Application.Interface;
    using ProjetoModeloDDD.Domain.Interfaces;   
    using ProjetoModeloDDD.Domain.Interfaces.Services;
    using ProjetoModeloDDD.Domain.Services;
    using ProjetoModeloDDD.Infra.Data.RepoADO;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //AppService
			kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
			kernel.Bind<IClienteAppService>().To<ClienteAppService>();
			kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<IProdutoAppServiceExtensao>().To<ProdutoAppServiceExtensao>();
            kernel.Bind<IEmpresaAppService>().To<EmpresaAppService>();
            kernel.Bind<IRegimeTributarioAppService>().To<RegimeTributarioAppService>();
            kernel.Bind<IConfiguracaoNFAppService>().To<ConfiguracaoNFAppService>();
            kernel.Bind<IDocumentoNotaFiscalAppService>().To<DocumentoNotaFiscalAppService>();
            kernel.Bind<INaturezaOperacaoAppService>().To<NaturezaOperacaoAppService>();
            kernel.Bind<IContabilidadeAppService>().To<ContabilidadeAppService>();
            kernel.Bind<ITipoGrupoImpostosAppService>().To<TipoGrupoImpostosAppService>();
            kernel.Bind<ITipoServicoAppService>().To<TipoServicoAppService>();
            kernel.Bind<IGrupoImpostosAppService>().To<GrupoImpostosAppService>();
            kernel.Bind<ICFOPAppService>().To<CFOPAppService>();
            kernel.Bind<IUnidadeComercialAppService>().To<UnidadeComercialAppService>();
            kernel.Bind<INCMAppService>().To<NCMAppService>();
            kernel.Bind<IProdutoServicoAppService>().To<ProdutoServicoAppService>();
            kernel.Bind<IPessoaAppService>().To<PessoaAppService>();            
            kernel.Bind<ITipoEnderecoPessoaAppService>().To<TipoEnderecoPessoaAppService>();
            kernel.Bind<IEnderecoPessoaAppService>().To<EnderecoPessoaAppService>();
            kernel.Bind<IPessoaFisicaAppService>().To<PessoaFisicaAppService>();
            kernel.Bind<IPessoaJuridicaAppService>().To<PessoaJuridicaAppService>();
            kernel.Bind<IIndicadorIEAppService>().To<IndicadorIEAppService>();

            //Service
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
			kernel.Bind<IClienteService>().To<ClienteService>();
			kernel.Bind<IProdutoService>().To<ProdutoService>();			
            kernel.Bind<IEmpresaService>().To<EmpresaService>();
            kernel.Bind<IRegimeTributarioService>().To<RegimeTributarioService>();
            kernel.Bind<IConfiguracaoNFService>().To<ConfiguracaoNFService>();
            kernel.Bind<IDocumentoNotaFiscalService>().To<DocumentoNotaFiscalService>();
            kernel.Bind<INaturezaOperacaoService>().To<NaturezaOperacaoService>();
            kernel.Bind<IContabilidadeService>().To<ContabilidadeService>();
            kernel.Bind<ITipoGrupoImpostosService>().To<TipoGrupoImpostosService>();
            kernel.Bind<ITipoServicoService>().To<TipoServicoService>();
            kernel.Bind<IGrupoImpostosService>().To<GrupoImpostosService>();
            kernel.Bind<ICFOPService>().To<CFOPService>();
            kernel.Bind<IUnidadeComercialService>().To<UnidadeComercialService>();
            kernel.Bind<INCMService>().To<NCMService>();
            kernel.Bind<IProdutoServicoService>().To<ProdutoServicoService>();
            kernel.Bind<IPessoaService>().To<PessoaService>();            
            kernel.Bind<ITipoEnderecoPessoaService>().To<TipoEnderecoPessoaService>();
            kernel.Bind<IEnderecoPessoaService>().To<EnderecoPessoaService>();
            kernel.Bind<IPessoaFisicaService>().To<PessoaFisicaService>();
            kernel.Bind<IPessoaJuridicaService>().To<PessoaJuridicaService>();
            kernel.Bind<IIndicadorIEService>().To<IndicadorIEService>();

            //Repository
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
			kernel.Bind<IClienteRepository>().To<ClienteRepository>();
			kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IEmpresaRepository>().To<EmpresaRepository>();
            kernel.Bind<IRegimeTributarioRepository>().To<RegimeTributarioRepository>();
            kernel.Bind<IConfiguracaoNFRepository>().To<ConfiguracaoNFRepository>();
            kernel.Bind<IDocumentoNotaFiscalRepository>().To<DocumentoNotaFiscalRepository>();
            kernel.Bind<INaturezaOperacaoRepository>().To<NaturezaOperacaoRepository>();
            kernel.Bind<IContabilidadeRepository>().To<ContabilidadeRepository>();            
            kernel.Bind<ITipoGrupoImpostosRepository>().To<TipoGrupoImpostosRepository>();
            kernel.Bind<ITipoServicoRepository>().To<TipoServicoRepository>();
            kernel.Bind<IGrupoImpostosRepository>().To<GrupoImpostosRepository>();
            kernel.Bind<ICFOPRepository>().To<CFOPRepository>();
            kernel.Bind<IUnidadeComercialRepository>().To<UnidadeComercialRepository>();
            kernel.Bind<INCMRepository>().To<NCMRepository>();
            kernel.Bind<IProdutoServicoRepository>().To<ProdutoServicoRepository>();
            kernel.Bind<IPessoaRepository>().To<PessoaRepository>();            
            kernel.Bind<ITipoEnderecoPessoaRepository>().To<TipoEnderecoPessoaRepository>();
            kernel.Bind<IEnderecoPessoaRepository>().To<EnderecoPessoaRepository>();
            kernel.Bind<IPessoaFisicaRepository>().To<PessoaFisicaRepository>();
            kernel.Bind<IPessoaJuridicaRepository>().To<PessoaJuridicaRepository>();
            kernel.Bind<IIndicadorIERepository>().To<IndicadorIERepository>();

        }        
    }
}
