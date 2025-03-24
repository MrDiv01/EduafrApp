using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
	public class Contact:BaseEntity
	{
		public string Location { get; set; }
		public string Phone { get; set; }
		public string Mail { get; set; }
	}
}
