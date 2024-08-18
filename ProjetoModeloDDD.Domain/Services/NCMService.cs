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
    public class NCMService: ServiceBase<NCM>, INCMService
    {
        private readonly INCMRepository _nCMRepository;
        public NCMService(INCMRepository nCMRepository) :
            base(nCMRepository)
        {
            _nCMRepository = nCMRepository;
        }
        public async Task<IEnumerable<NCM>> BuscarPorCodigoNCM(string codigoNCM)
        {
            return await _nCMRepository.BuscarPorCodigoNCM(codigoNCM);
        }
    }
}
