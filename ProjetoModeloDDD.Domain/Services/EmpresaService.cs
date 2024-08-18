using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class EmpresaService: ServiceBase<Empresa>, IEmpresaService //estende (herda) a classe implementada ServiceBase e implementa a interface IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository) :
            base(empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }
  
    }
}
