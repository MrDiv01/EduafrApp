using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
    public class CategoryTeacher:BaseEntity
    {
        public int TeacherId { get; set; }
        public int TeacherCategoryId { get; set; }
        public Teacher Teacher { get; set; }
        public TeacherCategory TeacherCategory { get; set; }
    }
}
