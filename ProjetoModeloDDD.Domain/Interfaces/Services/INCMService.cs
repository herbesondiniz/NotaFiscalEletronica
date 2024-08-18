using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface INCMService: IServiceBase<NCM>
    {
        Task<IEnumerable<NCM>> BuscarPorCodigoNCM(string nome);
    }
}
