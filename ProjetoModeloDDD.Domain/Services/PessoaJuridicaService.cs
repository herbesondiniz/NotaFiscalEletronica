using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PessoaJuridicaService: ServiceBase<PessoaJuridica>, IPessoaJuridicaService
    {
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        public PessoaJuridicaService(IPessoaJuridicaRepository pessoaJuridicaRepository) :
            base(pessoaJuridicaRepository) 
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
        }
    }
}
