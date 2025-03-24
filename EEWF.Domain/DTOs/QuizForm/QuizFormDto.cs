using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.DTOs.QuizForm
{
    public class QuizFormDto
    {
        public int QuizFormId { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
