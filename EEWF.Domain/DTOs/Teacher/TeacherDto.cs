using EEWF.Domain.DTOs.CategoryTeacher;
using EEWF.Domain.DTOs.TeacherCategory;
using EEWF.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.DTOs.Teacher
{
	public class TeacherDto
	{
		public int TeacherId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public IFormFile ImageFile { get; set; }
        public string category { get; set; }

        public TeacherCategoryDto Category { get; set; }
    }
}
