using Microsoft.AspNetCore.Mvc;
using NavigationApi.DataBase;
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
		/// Вернуть названия улиц.
		/// </summary>
		/// <returns>Названия улиц.</returns>
		[HttpGet]
		public object GetAllCars()
		{
			return new
			{
				Items = _dbContext.Cars.ToArray()
			};
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
