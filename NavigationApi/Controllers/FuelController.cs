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
	public class FuelController : ControllerBase
	{
		private NavigationDbContext _dbContext;
		public FuelController(NavigationDbContext context)
		{
			_dbContext = context;
		}

		/// <summary>
		/// Вернуть названия улиц.
		/// </summary>
		/// <returns>Названия улиц.</returns>
		[HttpGet]
		public object GetAllFuels()
		{
			return new
			{
				Items = _dbContext.Fuels.Select(x=> new { 
					Id = x.Id,
					Name = x.Name,
					Cost = x.CostPerLiter
				}).ToArray()
			};
		}

		/// <summary>
		/// Вернуть топливо.
		/// </summary>
		/// <returns>Топливо.</returns>
		[HttpPost]
		public object GetFuelById([FromBody]Guid id)
		{
			return _dbContext.Fuels.Where(x => x.Id == id).Select(x => new {
				Id = x.Id,
				Name = x.Name,
				Cost = x.CostPerLiter
			}).FirstOrDefault();
		}

		/// <summary>
		/// Добавить топливо.
		/// </summary>
		/// <param name="fuelToAdd">Топливо для добавления.</param>
		[HttpPost]
		public void AddFuel([FromBody] Fuel fuelToAdd)
		{
			if (fuelToAdd == null)
			{
				return;
			}

			fuelToAdd.Id = Guid.NewGuid();
			_dbContext.Fuels.Add(fuelToAdd);
			_dbContext.SaveChanges();
		}

		/// <summary>
		/// Обновить топливо.
		/// </summary>
		/// <param name="fuel">Топливо для добавления.</param>
		[HttpPost]
		public void UpdateFuel([FromBody] Fuel fuel)
		{
			if (fuel == null || fuel.Id == Guid.Empty)
			{
				return;
			}
			var carToUpdate = _dbContext.Fuels.Find(fuel.Id);
			carToUpdate.Name = fuel.Name;
			carToUpdate.CostPerLiter = fuel.CostPerLiter;
			_dbContext.SaveChanges();
		}

		/// <summary>
		/// Удалить машину.
		/// </summary>
		/// <param name="to">Трансферный объект.</param>
		[HttpDelete]
		public void DeleteFuel([FromBody] TransferIdObject to)
		{
			if (to == null || to.Id == Guid.Empty)
			{
				return;
			}

			_dbContext.Fuels.Remove(
				_dbContext.Fuels.First(x => x.Id == to.Id)
				);
			_dbContext.SaveChanges();
			return;
		}
	}
}
