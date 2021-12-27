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
	public class CarController : ControllerBase
	{
		private NavigationDbContext _dbContext;
		public CarController(NavigationDbContext context)
		{
			_dbContext = context;
		}

		/// <summary>
		/// Вернуть машины.
		/// </summary>
		/// <returns>Названия улиц.</returns>
		[HttpGet]
		public object GetAllCars()
		{
			return new
			{
				Items = _dbContext.Cars.Select(x=> new { 
					Id = x.Id,
					Mark = x.Mark,
					Fuel_type = x.Fuel.Name,
					Gas_mileage = x.FuelConsuption
				}).ToArray()
			};
		}

		/// <summary>
		/// Вернуть названия улиц.
		/// </summary>
		/// <returns>Машина.</returns>
		[HttpPost]
		public object GetCarByName([FromBody]string mark)
		{
			return _dbContext.Cars.Where(x => x.Mark == mark).Select(x => new
			{
				Id = x.Id,
				Mark = x.Mark,
				FuelId = x.FuelId,
				FuelConsuption = x.FuelConsuption
			}).FirstOrDefault();
		}

		/// <summary>
		/// Добавить машину.
		/// </summary>
		/// <param name="carToAdd">Улица для добавления.</param>
		[HttpPost]
		public void AddCar([FromBody] Car carToAdd)
		{
			if (carToAdd == null)
			{
				return;
			}

			carToAdd.Id = Guid.NewGuid();
			_dbContext.Cars.Add(carToAdd);
			_dbContext.SaveChanges();
		}

		/// <summary>
		/// Обновить машину.
		/// </summary>
		/// <param name="car">Машина для добавления.</param>
		[HttpPost]
		public void UpdateCar([FromBody] Car car)
		{
			if (car == null || car.Id == Guid.Empty)
			{
				return;
			}
			var carToUpdate = _dbContext.Cars.Find(car.Id);
			carToUpdate.Mark = car.Mark;
			carToUpdate.FuelConsuption = car.FuelConsuption;
			carToUpdate.FuelId = car.FuelId;
			_dbContext.SaveChanges();
		}


		/// <summary>
		/// Удалить машину.
		/// </summary>
		/// <param name="to">Трансферный объект.</param>
		[HttpDelete]
		public void DeleteCar([FromBody] TransferIdObject to)
		{
			if (to == null || to.Id == Guid.Empty)
			{
				return;
			}

			_dbContext.Cars.Remove(
				_dbContext.Cars.First(x => x.Id == to.Id)
				);
			_dbContext.SaveChanges();
			return;
		}
	}
}
