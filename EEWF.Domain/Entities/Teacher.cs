using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
	public class Teacher:BaseEntity
	{
        public string Name { get; set; }
		public string Surname { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
        //public int TeacherCategoryId { get; set; }

        //public TeacherCategory TeacherCategory { get; set; }
        public ICollection<CategoryTeacher> CategoryTeachers { get; set; }
    }
}
