using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class CFOPService: ServiceBase<CFOP>, ICFOPService //estende (herda) a classe implementada ServiceBase e implementa a interface IClienteService
    {
        private readonly ICFOPRepository _CFOPRepository;

        public CFOPService(ICFOPRepository CFOPRepository) :
            base(CFOPRepository)
        {
            _CFOPRepository = CFOPRepository;
        }

        public async Task<IEnumerable<CFOP>> BuscarPorTipoGrupoImpostosId(int id)
        {
            return await _CFOPRepository.BuscarPorTipoGrupoImpostosId(id);
        }
    }
}
