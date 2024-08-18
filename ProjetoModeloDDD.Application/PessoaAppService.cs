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
    public class PessoaAppService: AppServiceBase<Pessoa>, IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;
        public PessoaAppService(IPessoaService pessoaService)
            : base(pessoaService)
        {
            _pessoaService = pessoaService;
        }
    }
}
