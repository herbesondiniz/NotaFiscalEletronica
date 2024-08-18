using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    public interface INCMRepository: IRepositoryBase<NCM>
    {
        Task<IEnumerable<NCM>> BuscarPorCodigoNCM(string codigoNCM);
    }
}
