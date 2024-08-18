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
    public class EnderecoPessoaAppService: AppServiceBase<EnderecoPessoa>, IEnderecoPessoaAppService
    {
        private readonly IEnderecoPessoaService _enderecoPessoaService;
        public EnderecoPessoaAppService(IEnderecoPessoaService enderecoPessoaService)
            : base(enderecoPessoaService)
        {
            _enderecoPessoaService = enderecoPessoaService;
        }
    }
}
