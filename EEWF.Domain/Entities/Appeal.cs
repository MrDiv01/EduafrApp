using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
	public class Appeal:BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public bool IsAnswer { get; set; }

		public AppealAnswer AppealAnswer { get; set; }
    }
}
