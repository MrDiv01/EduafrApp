using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.DTOs.Graduate
{
	public class GraduateDto
	{
		public int GraduateId { get; set; }
		public string Image { get; set; }
		public string Name { get; set; }
		public string Degree { get; set; }
		public string Comment { get; set; }
		public IFormFile ImageFile { get; set; }
	}
}
