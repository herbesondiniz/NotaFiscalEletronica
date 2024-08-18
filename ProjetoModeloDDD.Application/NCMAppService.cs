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
    public class NCMAppService: AppServiceBase<NCM>, INCMAppService
    {
        private readonly INCMService _nCMService;
        public NCMAppService(INCMService nCMService)
            : base(nCMService)
        {
            _nCMService = nCMService;
        }

        public async Task<IEnumerable<NCM>> BuscarPorCodigoNCM(string codigoNCM)
        {
            return await _nCMService.BuscarPorCodigoNCM(codigoNCM);
        }
    }
}
