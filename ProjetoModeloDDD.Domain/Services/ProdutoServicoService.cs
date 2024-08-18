using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ProdutoServicoService: ServiceBase<ProdutoServico>, IProdutoServicoService
    {
        private readonly IProdutoServicoRepository _produtoServicoRepository;
        public ProdutoServicoService(IProdutoServicoRepository produroServicoRepository) :
            base(produroServicoRepository)
        {
            _produtoServicoRepository = produroServicoRepository;
        }
    }
}
