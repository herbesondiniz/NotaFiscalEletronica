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
    public class TipoEnderecoPessoaAppService: AppServiceBase<TipoEnderecoPessoa>, ITipoEnderecoPessoaAppService
    {
        private readonly ITipoEnderecoPessoaService _tipoEnderecoPessoaService;
        public TipoEnderecoPessoaAppService(ITipoEnderecoPessoaService tipoEnderecoPessoaService)
            : base(tipoEnderecoPessoaService)
        {
            _tipoEnderecoPessoaService = tipoEnderecoPessoaService;
        }
    }
}
