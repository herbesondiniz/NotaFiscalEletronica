using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.RepoADO
{
    public class PessoaFisicaRepository: IPessoaFisicaRepository
    {
        private readonly IRepositoryBase<PessoaFisica> _repositoryBase;
		private readonly IPessoaFisicaRepository _pessoaFisica;

		public PessoaFisicaRepository(IRepositoryBase<PessoaFisica> repositoryBase, IPessoaFisicaRepository pessoaFisica)
        {
			_repositoryBase = repositoryBase;
			_pessoaFisica = pessoaFisica;
		}
    }
}
