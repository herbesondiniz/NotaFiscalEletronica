using Dapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.RepoADO
{
    public class RegimeTributarioRepository : RepositoryBase<RegimeTributario>, IRegimeTributarioRepository    
    {
        public async Task<IEnumerable<RegimeTributario>> BuscarPorNome(string nome)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<IEnumerable<RegimeTributario>>($"SELECT * FROM {_tableName} WHERE nome=@Nome", new { Nome = nome });
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} com nome [{nome}] não encontrado.");

                return result;
            }
        }
    }
}
