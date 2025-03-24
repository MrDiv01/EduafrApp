using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
	public class QuizForm : BaseEntity
	{
		public string Name { get; set; }
		public string SureName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public int? CorectAnswerCount { get; set; }
		public int? FalseAnswerCount { get; set; }
		public int? Point { get; set; }
		public int? LevelId { get; set; }
		public Level Level { get; set; }
	}
}
