using EEWF.Application.Core;
using EEWF.Application.CQRS.Carousel.Commands.CreateCarousel;
using EEWF.Application.CQRS.Carousel.Commands.UpdateCarousel;
using EEWF.Domain.DTOs.Carousel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
    public interface ICarouselService
    {
        Task<ServiceResult<List<CarouselDto>>> GetCarousel();
        Task<ServiceResult<CarouselDto>> GetCarouselById(int carouselId);

        Task<ServiceResult<int>> CreateCarousel(CreateCarouselCommand command);
        Task<ServiceResult<int>> UpdateCarousel(UpdateCarouselCommand command);


    }
}
