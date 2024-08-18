using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
	public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
	{
		private readonly IRepositoryBase<TEntity> _repository;

		public ServiceBase(IRepositoryBase<TEntity> repository)
		{
			_repository = repository;
		}
		public async Task<int> Add(TEntity obj)
		{
			return await _repository.Add(obj);
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await _repository.GetAll();
		}

		public async Task<TEntity> GetById(int id)
		{
			return await _repository.GetById(id);
		}		

		public async Task Update(TEntity obj)
		{
			await _repository.Update(obj);
		}
		public async Task Remove(TEntity obj)
		{
			await _repository.Remove(obj);
		}					
	}
}
