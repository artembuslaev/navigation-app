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
	public class NavigationAppController : ControllerBase
	{
		private NavigationDbContext _dbContext;
		public NavigationAppController(NavigationDbContext context)
		{
			_dbContext = context;
		}

		/// <summary>
		/// Вернуть названия улиц.
		/// </summary>
		/// <returns>Названия улиц.</returns>
		[HttpGet]
		public string[] GetStreetsName()
		{
			return _dbContext.Streets
				.Select(x=>x.Name)
				.ToArray();
		}
	}
}
