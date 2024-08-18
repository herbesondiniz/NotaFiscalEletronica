using Dapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.RepoADO
{
    public class NCMRepository: RepositoryBase<NCM>, INCMRepository
	{
		public async Task<IEnumerable<NCM>> BuscarPorCodigoNCM(string codigoNCM)
		{
			using (var connection = CreateConnection())
			{
				var result = await connection.QueryAsync<NCM>($"SELECT * FROM {_tableName} WHERE CodigoNCM=@CodigoNCM", new { CodigoNCM = codigoNCM });			
				if (result == null)
					throw new KeyNotFoundException($"{_tableName} com nome [{codigoNCM}] não encontrado.");

				return result;
			}
		}
	}
}
