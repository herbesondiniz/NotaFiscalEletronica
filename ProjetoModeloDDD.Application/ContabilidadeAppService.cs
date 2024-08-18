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
    public class ContabilidadeAppService : AppServiceBase<Contabilidade>, IContabilidadeAppService
    {
        private readonly IContabilidadeService _contabilidadeService;
        public ContabilidadeAppService(IContabilidadeService contabilidadeService)
            : base(contabilidadeService)
        {
            _contabilidadeService = contabilidadeService;
        }
    }
}
