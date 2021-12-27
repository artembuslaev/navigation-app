using Microsoft.AspNetCore.Mvc;
using NavigationApi.DataBase;
using NavigationApi.DataBase.Models;
using NavigationApi.DtoModels;
using System;
using System.Linq;

namespace NavigationApi.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class RoadTypeController : ControllerBase
	{
		private NavigationDbContext _dbContext;
		public RoadTypeController(NavigationDbContext context)
		{
			_dbContext = context;
		}

		/// <summary>
		/// Вернуть дорожные покрытия.
		/// </summary>
		/// <returns>Названия дорожные покрытия.</returns>
		[HttpGet]
		public object GetAllRoadTypes()
		{
			return new
			{
				Items = _dbContext.RoadTypes.Select(x=> new { 
					Id = x.Id,
					Name = x.Name,
					Coefficient = x.BrakingRatio
				}).ToArray()
			};
		}

		/// <summary>
		/// Добавить покрытие.
		/// </summary>
		/// <param name="roadTypeToAdd">Покрытие для добавления.</param>
		[HttpPost]
		public void AddRoadType([FromBody] RoadType roadTypeToAdd)
		{
			if (roadTypeToAdd == null)
			{
				return;
			}

			roadTypeToAdd.Id = Guid.NewGuid();
			_dbContext.RoadTypes.Add(roadTypeToAdd);
			_dbContext.SaveChanges();
		}

		/// <summary>
		/// Обновить покрытие.
		/// </summary>
		/// <param name="roadType">Покрытие для обновления.</param>
		[HttpPost]
		public void UpdateRoadType([FromBody] RoadType roadType)
		{
			if (roadType == null || roadType.Id == Guid.Empty)
			{
				return;
			}
			var roadTypeToUpdate = _dbContext.RoadTypes.Find(roadType.Id);
			roadTypeToUpdate.Name = roadType.Name;
			roadTypeToUpdate.BrakingRatio = roadType.BrakingRatio;
			_dbContext.SaveChanges();
		}

		/// <summary>
		/// Удалить дорожное покрытие.
		/// </summary>
		/// <param name="to">Трансферный объект.</param>
		[HttpDelete]
		public void DeleteRoadType([FromBody] TransferIdObject to)
		{
			if (to == null || to.Id == Guid.Empty)
			{
				return;
			}

			_dbContext.RoadTypes.Remove(
				_dbContext.RoadTypes.First(x => x.Id == to.Id)
				);
			_dbContext.SaveChanges();
			return;
		}
	}
}