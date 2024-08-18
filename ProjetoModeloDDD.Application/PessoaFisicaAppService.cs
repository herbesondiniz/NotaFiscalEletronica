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
    public class PessoaFisicaAppService: IPessoaFisicaAppService
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;
        private readonly IAppServiceBase<PessoaFisica> _appServiceBase;
		public PessoaFisicaAppService(IAppServiceBase<PessoaFisica> appServiceBase, IPessoaFisicaService pessoaFisicaService)            
        {
			_appServiceBase = appServiceBase;
			_pessoaFisicaService = pessoaFisicaService;
        }
    }
}
