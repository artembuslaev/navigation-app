using Microsoft.AspNetCore.Mvc;
using NavigationApi.DataBase;
using NavigationApi.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NavigationApi.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class StreetController : ControllerBase
	{
		private NavigationDbContext _dbContext;
		public StreetController(NavigationDbContext context)
		{
			_dbContext = context;
		}

		/// <summary>
		/// Вернуть названия улиц.
		/// </summary>
		/// <returns>Названия улиц.</returns>
		[HttpGet]
		public Street[] GetAllStreets()
		{
			return _dbContext.Streets.ToArray();
		}

		[HttpPost]
		public void AddStreet([FromBody] Street streetToAdd)
		{
			streetToAdd.Id = Guid.NewGuid();
			_dbContext.Streets.Add(streetToAdd);
			_dbContext.SaveChanges();
		}

		[HttpPost]
		public void UpdateStreet([FromBody] Street street)
		{
			var streetToUpdate = _dbContext.Streets.Find(street.Id);
			streetToUpdate.Length = street.Length;
			streetToUpdate.Name = street.Name;
			_dbContext.SaveChanges();
		}
	}
}
