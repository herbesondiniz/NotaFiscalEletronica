using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class EnderecoService: ServiceBase<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoService(IEnderecoRepository enderecoRepository) :
            base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
    }
}
