using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.RepoADO
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		protected readonly string _tableName;
		protected readonly string _nomeIdCampo;
		protected readonly List<PropertyInfo> _camposDatas;		

		protected IEnumerable<PropertyInfo> GetProperties => typeof(TEntity).GetProperties();
		public RepositoryBase()
		{
			_tableName = typeof(TEntity).Name;
			_nomeIdCampo = GetProperties.Where(p => p.Name == p.ReflectedType.Name + "Id").FirstOrDefault().Name;
			_camposDatas = GetProperties.Where(p => p.PropertyType == typeof(DateTime)).ToList();
			//_nomeDataCampo = GetProperties.Where(p => p.PropertyType.FullName.Contains("System.DateTime")).FirstOrDefault() == null ? "" : GetProperties.Where(p => p.PropertyType.FullName.Contains("System.DateTime")).FirstOrDefault().Name;			
		}

		protected SqlConnection SqlConnection()
		{
			return new SqlConnection(ConfigurationManager.ConnectionStrings["ProjetoModeloDDD"].ConnectionString);
		}

		protected IDbConnection CreateConnection()
		{
			var conn = SqlConnection();
			conn.Open();
			return conn;
		}

		private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
		{
			var name = Assembly.GetExecutingAssembly().FullName;
			name = name.Substring(0, name.IndexOf("."));

			return (from prop in listOfProperties
					let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
					where !prop.PropertyType.FullName.ToString().Contains(name) && (attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore")
					select prop.Name).ToList();
		}

		protected string GenerateInsertQuery()
		{
			var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

			insertQuery.Append("(");

			var properties = GenerateListOfProperties(GetProperties);
			properties.ForEach(prop => 
			{
				if (!prop.Equals(_nomeIdCampo))
				{
					insertQuery.Append($"[{prop}],");
				}
					
			});

			insertQuery
				.Remove(insertQuery.Length - 1, 1)
				.Append(") VALUES (");

			properties.ForEach(prop => 
			{
				_camposDatas.ForEach(t =>
				{

					if (t.Name.Equals(prop))
					{
						object propValue = DateTime.Now;

						DateTime dt = Convert.ToDateTime(propValue.ToString());
						string data = dt.ToString("yyyy-MM-dd hh:mm:ss.000", System.Globalization.CultureInfo.InvariantCulture);
						propValue = data;

						insertQuery.Append($" CAST('{propValue.ToString()}' AS datetime),");
					}
				});

				if (!prop.Equals(_nomeIdCampo) && !_camposDatas.Any(c => c.Name == prop))
				{
					insertQuery.Append($"@{prop},");
				}
					
			});

			insertQuery
				.Remove(insertQuery.Length - 1, 1)
				.Append(");")
				.Append("SELECT CAST(SCOPE_IDENTITY() as int)");			

			return insertQuery.ToString();
		}
		public async Task<int> Add(TEntity obj)
		{
			var insertQuery = GenerateInsertQuery();

			using (var connection = CreateConnection())
			{
				//var teste =  await connection.ExecuteAsync(insertQuery, obj);				
				var id = await connection.QueryAsync<int>(insertQuery, obj);
				return id.Single();
			}
		}

		public async Task<TEntity> GetById(int id)
		{
			using (var connection = CreateConnection())
			{
				var result = await connection.QuerySingleOrDefaultAsync<TEntity>($"SELECT * FROM {_tableName} WHERE {_nomeIdCampo}=@Id", new { Id = id });
				if (result == null)
					throw new KeyNotFoundException($"{_tableName} com id [{id}] não encontrado.");

				return result;
			}
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			using (var connection = CreateConnection())
			{
				return await connection.QueryAsync<TEntity>($"SELECT * FROM {_tableName}");								
			}
		}

		private string GenerateUpdateQuery(TEntity obj)
		{
			var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
			var properties = GenerateListOfProperties(GetProperties);			

			properties.ForEach(property =>
			{								
				if (!property.Equals(_nomeIdCampo) && !_camposDatas.Any(c=>c.Name == property))
				{					
					updateQuery.Append($"{property}=@{property},");
				}
			});

			int idValue = (int)obj.GetType().GetProperty(_nomeIdCampo).GetValue(obj, null);

			updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma			
			updateQuery.Append($" WHERE {_nomeIdCampo}=@{_nomeIdCampo}");

			return updateQuery.ToString();
		}

		public async Task Update(TEntity obj)
		{
			int idValue = (int)obj.GetType().GetProperty(_nomeIdCampo).GetValue(obj, null);
			var updateQuery = GenerateUpdateQuery(obj);

			using (var connection = CreateConnection())
			{
				await connection.ExecuteAsync(updateQuery, obj);
			}
		}

		public async Task Remove(TEntity obj)
		{
			int idValue = (int)obj.GetType().GetProperty(_nomeIdCampo).GetValue(obj, null);

			using (var connection = CreateConnection())
			{
				await connection.ExecuteAsync($"DELETE FROM {_tableName} WHERE {_nomeIdCampo}=@Id", new { Id = idValue });
			}
		}
	}
}
