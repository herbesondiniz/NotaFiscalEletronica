using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface INCMAppService: IAppServiceBase<NCM>
    {
        Task<IEnumerable<NCM>> BuscarPorCodigoNCM(string codigoNCM);
    }
}
