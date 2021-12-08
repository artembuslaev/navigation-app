using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NavigationApi.DataBase.Models
{
	public class Car
	{
		[Key]
		public Guid Id { get; set; }

		[MaxLength(50)]
		[Required]
		public string Mark { get; set; }

		[Required]
		public int MaxSpeed { get; set; }

		/// <summary>
		/// Расход топлива.
		/// </summary>
		[Required]
		public int FuelConsuption { get; set; }

		[Required]
		public Guid FuelId { get; set; }
		public Fuel Fuel { get; set; }
	}
}
