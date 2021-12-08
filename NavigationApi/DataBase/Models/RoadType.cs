using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NavigationApi.DataBase.Models
{
	/// <summary>
	/// Дорожное покрытие.
	/// </summary>
	public class RoadType
	{
		[Key]
		public Guid Id { get; set; }

		[MaxLength(50)]
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Коэффициент торможения.
		/// </summary>
		public double BrakingRatio { get; set; }
	}
}
