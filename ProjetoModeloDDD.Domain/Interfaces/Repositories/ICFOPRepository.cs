using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces
{
    public interface ICFOPRepository: IRepositoryBase<CFOP>
    {
        Task<IEnumerable<CFOP>> BuscarPorTipoGrupoImpostosId(int id);
    }
}
