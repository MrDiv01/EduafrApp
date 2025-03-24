using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.DTOs.Variant
{
    public class VariantDto
    {
        public int VariantId { get; set; }
        public bool IsCorrect { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //Question
        public int QuestionId { get; set; }
    }
}
