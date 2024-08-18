using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class PessoaFisicaService: IPessoaFisicaService
    {
        private readonly IRepositoryBase<PessoaFisica> _repositoryBase;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        public PessoaFisicaService(IRepositoryBase<PessoaFisica> repositoryBase, IPessoaFisicaRepository pessoaFisicaRepository)           
        {
            _repositoryBase = repositoryBase;
			_pessoaFisicaRepository = pessoaFisicaRepository;
        }
    }
}
