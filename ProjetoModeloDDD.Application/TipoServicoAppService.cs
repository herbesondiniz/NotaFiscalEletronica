using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class TipoServicoAppService: AppServiceBase<TipoServico>, ITipoServicoAppService
    {
        private readonly ITipoServicoService _tipoServicoService;
        public TipoServicoAppService(ITipoServicoService tipoServicoService)
            : base(tipoServicoService)
        {
            _tipoServicoService = tipoServicoService;
        }
    }
}
