using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Carousel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Carousel.Queries.GetCarousel
{

    internal class GetCarouselQueryHandler : IRequestHandler<GetCarouselQeuery, ServiceResult<List<CarouselDto>>>

    {
        private readonly ICarouselService _carouselService;

        public GetCarouselQueryHandler(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        public async Task<ServiceResult<List<CarouselDto>>> Handle(GetCarouselQeuery request, CancellationToken cancellationToken)

        {
            var result = await _carouselService.GetCarousel();
            return result;
        }
    }
}
