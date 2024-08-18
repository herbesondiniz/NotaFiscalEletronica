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
    public class RegimeTributarioAppService : AppServiceBase<RegimeTributario>, IRegimeTributarioAppService
    {
        private readonly IRegimeTributarioService _regimeTributarioService;
        public RegimeTributarioAppService(IRegimeTributarioService regimeTributarioService)
            : base(regimeTributarioService)
        {
            _regimeTributarioService = regimeTributarioService;
        }
        public async Task<IEnumerable<RegimeTributario>> BuscarPorNome(string nome)
        {
            return await _regimeTributarioService.BuscarPorNome(nome);
        }
    }
}
