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
	public class DriverController : ControllerBase
	{
		private NavigationDbContext _dbContext;
		public DriverController(NavigationDbContext context)
		{
			_dbContext = context;
		}

		/// <summary>
		/// Вернуть названия улиц.
		/// </summary>
		/// <returns>Названия улиц.</returns>
		[HttpGet]
		public object GetAllDrivers()
		{
			return new
			{
				Items = _dbContext.Drivers.Select(x=> new { 
					Id = x.Id,
					Fio = x.FullName,
					Car = x.Car.Mark,
					Decency = x.IsIntruder
				}).ToArray()
			};
		}

		/// <summary>
		/// Добавить водителя.
		/// </summary>
		/// <param name="driverToAdd">Водитель для добавления.</param>
		[HttpPost]
		public void AddDriver([FromBody] Driver driverToAdd)
		{
			if (driverToAdd == null)
			{
				return;
			}

			driverToAdd.Id = Guid.NewGuid();
			_dbContext.Drivers.Add(driverToAdd);
			_dbContext.SaveChanges();
		}

		/// <summary>
		/// Обновить водителя.
		/// </summary>
		/// <param name="driver">Водитель для добавления.</param>
		[HttpPost]
		public void UpdateDriver([FromBody] Driver driver)
		{
			if (driver == null || driver.Id == Guid.Empty)
			{
				return;
			}
			var driverToUpdate = _dbContext.Drivers.Find(driver.Id);
			driverToUpdate.FullName = driver.FullName;
			driverToUpdate.IsIntruder = driver.IsIntruder;
			driverToUpdate.CarId = driver.CarId;
			_dbContext.SaveChanges();
		}

		/// <summary>
		/// Удалить водителя.
		/// </summary>
		/// <param name="to">Трансферный объект.</param>
		[HttpDelete]
		public void DeleteDriver([FromBody] TransferIdObject to)
		{
			if (to == null || to.Id == Guid.Empty)
			{
				return;
			}

			_dbContext.Drivers.Remove(
				_dbContext.Drivers.First(x => x.Id == to.Id)
				);
			_dbContext.SaveChanges();
			return;
		}
	}
}
