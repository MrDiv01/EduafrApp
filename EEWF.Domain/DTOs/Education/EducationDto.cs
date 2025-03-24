using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.DTOs.Education
{
    public class EducationDto
    {

        public int EducationId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int LevelId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
