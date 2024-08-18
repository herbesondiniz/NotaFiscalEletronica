using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class TipoEnderecoPessoaService: ServiceBase<TipoEnderecoPessoa>, ITipoEnderecoPessoaService
    {
        private readonly ITipoEnderecoPessoaRepository _tipoEnderecoPessoaRepository;
        public TipoEnderecoPessoaService(ITipoEnderecoPessoaRepository tipoEnderecoPessoaRepository) :
            base(tipoEnderecoPessoaRepository)
        {
            _tipoEnderecoPessoaRepository = tipoEnderecoPessoaRepository;
        }
    }
}
