using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.RepoADO
{
    public class PessoaRepository: RepositoryBase<Pessoa>, IPessoaRepository
    {
    }
}
