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
    public class RegimeTributarioService : ServiceBase<RegimeTributario>, IRegimeTributarioService
    {
        private readonly IRegimeTributarioRepository _regimeTributarioRepository;

        public RegimeTributarioService(IRegimeTributarioRepository regimeTributarioRepository) :
            base(regimeTributarioRepository)
        {
            _regimeTributarioRepository = regimeTributarioRepository;
        }

        public async Task<IEnumerable<RegimeTributario>> BuscarPorNome(string nome)
        {
            return await _regimeTributarioRepository.BuscarPorNome(nome);
        }
    }
}
