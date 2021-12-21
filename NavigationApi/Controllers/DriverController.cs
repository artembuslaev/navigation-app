using Microsoft.AspNetCore.Mvc;
using NavigationApi.DataBase;
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
				Items = _dbContext.Drivers.ToArray()
			};
		}

		/// <summary>
		/// Удалить машину.
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
