using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NavigationApi.DataBase.Models
{
	public class Driver
	{
		[Key]
		public Guid Id { get; set; }

		[MaxLength(100)]
		[Required]
		public string FullName { get; set; }

		/// <summary>
		/// Нарушитель.
		/// </summary>
		[Required]
		public bool IsIntruder { get; set; }

		public Guid CarId { get; set; }
		public Car Car { get; set; }

	}
}
