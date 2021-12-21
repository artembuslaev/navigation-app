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
		public object GetAllStreetsForTable()
		{
			return new
			{
				Items = _dbContext.Streets.ToArray()
			};
		}

		/// <summary>
		/// Добавить улицу.
		/// </summary>
		/// <param name="streetToAdd">Улица для добавления.</param>
		[HttpPost]
		public void AddStreet([FromBody] Street streetToAdd)
		{
			if (streetToAdd == null)
			{
				return;
			}

			streetToAdd.Id = Guid.NewGuid();
			_dbContext.Streets.Add(streetToAdd);
			_dbContext.SaveChanges();
		}

		[HttpPost]
		public void UpdateStreet([FromBody] Street street)
		{
			if (street == null || street.Id == Guid.Empty)
			{
				return;
			}

			var streetToUpdate = _dbContext.Streets.Find(street.Id);
			streetToUpdate.Length = street.Length;
			streetToUpdate.Name = street.Name;
			_dbContext.SaveChanges();
		}

		[HttpDelete]
		public void DeleteStreet([FromBody] TransferIdObject to)
		{
			if (to == null || to.Id == Guid.Empty)
			{
				return;
			}

			_dbContext.Streets.Remove(
				_dbContext.Streets.First(x => x.Id == to.Id)
				);
			_dbContext.SaveChanges();
			return;
		}
	}
}
