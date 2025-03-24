using EEWF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.DTOs.Question
{
    public class QuestionDto
    {
        public string Query { get; set; }
        public double Point { get; set; }
        //public ICollection<Variant> variants { get; set; }
        //Level
        public int LevelId { get; set; }
    }
}