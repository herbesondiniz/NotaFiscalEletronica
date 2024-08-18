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
    public class PessoaJuridicaAppService: AppServiceBase<PessoaJuridica>, IPessoaJuridicaAppService
    {
        private readonly IPessoaJuridicaService _pessoaJuridicaService;

        public PessoaJuridicaAppService(IPessoaJuridicaService pessoaJuridicaService) : base(pessoaJuridicaService) 
        {
            _pessoaJuridicaService = pessoaJuridicaService;
        }
    }
}
