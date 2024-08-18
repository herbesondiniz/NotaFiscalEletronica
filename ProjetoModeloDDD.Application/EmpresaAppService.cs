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
    public class EmpresaAppService: AppServiceBase<Empresa>, IEmpresaAppService
    {
        private readonly IEmpresaService _empresaService;
        public EmpresaAppService(IEmpresaService empresaService)
            : base(empresaService)
        {
            _empresaService = empresaService;
        }
    }
}
