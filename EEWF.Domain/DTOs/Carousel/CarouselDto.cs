using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.DTOs.Carousel
{
    public class CarouselDto
    {
        public int CarouselId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string ButtonText { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
