using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
	public interface IServiceBase<TEntity> where TEntity : class
	{
		Task<int> Add(TEntity obj);
		Task<TEntity> GetById(int id);
		Task<IEnumerable<TEntity>> GetAll();
		Task Update(TEntity obj);
		Task Remove(TEntity obj);		
	}
}
