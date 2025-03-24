using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
	public class Category:BaseEntity
	{
		public string Name { get; set; }
		public string Icon { get; set; }
		public string Description { get; set; }
	}
}
