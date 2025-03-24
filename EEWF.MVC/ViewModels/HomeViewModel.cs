using EEWF.Domain.DTOs.Carousel;
using EEWF.Domain.DTOs.Category;
using EEWF.Domain.DTOs.Education;
using EEWF.Domain.DTOs.Graduate;
using EEWF.Domain.DTOs.Level;
using EEWF.Domain.Entities;

namespace EEWF.MVC.ViewModels
{
    public class HomeViewModel
    {
       public List<CarouselDto> carousels { get; set; }
        public List<CategoryDto> categories { get; set; }
        public List<GraduateDto> graduates { get; set; }
        public List<LevelDto> level { get; set; }
    }
}
