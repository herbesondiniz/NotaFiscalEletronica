using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PessoaService: ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaService(IPessoaRepository pessoaRepository) :
            base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
    }
}
