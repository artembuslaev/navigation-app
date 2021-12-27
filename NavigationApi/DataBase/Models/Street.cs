using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NavigationApi.DataBase.Models
{
	public class Street
	{
		[Key]
		public Guid Id { get; set; }

		[MaxLength(50)]
		[Required]
		public string Name { get; set; }

		public int Length { get; set; }
	}
}
