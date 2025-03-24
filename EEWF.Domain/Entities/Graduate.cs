using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
	public class Graduate:BaseEntity
	{
		public string Image { get; set; }
		public string Name { get; set; }
		public string Degree { get; set; }
		public string Comment { get; set; }
	}
}
