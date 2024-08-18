using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class EnderecoPessoaService: ServiceBase<EnderecoPessoa>, IEnderecoPessoaService
    {
        private readonly IEnderecoPessoaRepository _enderecoPessoaRepository;
        public EnderecoPessoaService(IEnderecoPessoaRepository enderecoPessoaRepository) :
            base(enderecoPessoaRepository)
        {
            _enderecoPessoaRepository = enderecoPessoaRepository;
        }
    }
}
