using Dapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.RepoADO
{
    public class CFOPRepository : RepositoryBase<CFOP>, ICFOPRepository
    {
		public async Task<IEnumerable<CFOP>> BuscarPorTipoGrupoImpostosId(int id)
		{
			using (var connection = CreateConnection())
			{				
				var result = await connection.QueryAsync<CFOP>($"SELECT * FROM {_tableName} WHERE TipoGrupoImpostosId=@Id", new { Id = id });				
				if (result == null)
					throw new KeyNotFoundException($"{_tableName} com id [{id}] não encontrado.");

				return result;
			}
		}
    }
}
