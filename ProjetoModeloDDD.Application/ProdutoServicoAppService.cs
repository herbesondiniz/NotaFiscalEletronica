using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class ProdutoServicoAppService: AppServiceBase<ProdutoServico>, IProdutoServicoAppService
    {
        private readonly IProdutoServicoService _produtoSericoService;
        public ProdutoServicoAppService(IProdutoServicoService produtoServicoService)
            : base(produtoServicoService)
        {
            _produtoSericoService = produtoServicoService;
        }
    }
}
