using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
	public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
	{
		private readonly IServiceBase<TEntity> _serviceBase;

		public AppServiceBase(IServiceBase<TEntity> serviceBase)
		{
			_serviceBase = serviceBase;
		}
		public async Task<int> Add(TEntity obj)
		{
			return await _serviceBase.Add(obj);
		}				

		public async Task<TEntity> GetById(int id)
		{
			return await _serviceBase.GetById(id);
		}
		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await _serviceBase.GetAll();
		}

		public async Task Remove(TEntity obj)
		{
			await _serviceBase.Remove(obj);
		}

		public async Task Update(TEntity obj)
		{
			await _serviceBase.Update(obj);
		}	
	}
}
