using Dapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.RepoADO
{
	public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
	{
		public async Task<IEnumerable<Produto>> BuscarPorNome(string nome)
		{
			using (var connection = CreateConnection())
			{
				var result = await connection.QuerySingleOrDefaultAsync<IEnumerable<Produto>>($"SELECT * FROM {_tableName} WHERE nome=@Nome", new { Nome = nome });
				if (result == null)
					throw new KeyNotFoundException($"{_tableName} com nome [{nome}] não encontrado.");

				return result;
			}
		}
	}
}
