using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
	public class Education:BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public int LevelId { get; set; }
        public Level Level { get; set; }
    }
}
