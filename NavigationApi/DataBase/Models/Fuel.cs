using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NavigationApi.DataBase.Models
{
	public class Fuel
	{
		[Key]
		public Guid Id { get; set; }

		[MaxLength(50)]
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Стоимость за литр.
		/// </summary>
		[Required]
		public double CostPerLiter { get; set; }
	}
}
