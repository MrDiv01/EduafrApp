using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
	public class TeacherCategory:BaseEntity
	{
		//About teacher
		public string Name { get; set; }

		//public ICollection<Teacher> Teachers { get; set; }
        public ICollection<CategoryTeacher> CategoryTeachers { get; set; }
    }
}
