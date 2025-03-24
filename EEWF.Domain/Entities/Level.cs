using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
    public class Level:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Education> Educations { get; set; }
    }
}
