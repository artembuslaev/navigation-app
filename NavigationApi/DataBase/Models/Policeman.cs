using NavigationApi.DataBase.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NavigationApi.DataBase.Models
{
	public class Policeman
	{
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Темперамент полицейского: добрый, злой, умеренный.
		/// </summary>
		[MaxLength(100)]
		[Required]
		public PolicemanMood PolicemanMood { get; set; }

		/// <summary>
		/// Штраф в рублях.
		/// </summary>
		public double FinePerRoubles { get; set; }
	}
}
