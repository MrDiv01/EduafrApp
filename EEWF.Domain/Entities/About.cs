using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
	public class About : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
    }
	
}
