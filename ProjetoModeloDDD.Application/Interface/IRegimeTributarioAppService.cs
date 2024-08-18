using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IRegimeTributarioAppService : IAppServiceBase<RegimeTributario>
    {
        Task<IEnumerable<RegimeTributario>> BuscarPorNome(string nome);
    }
}
