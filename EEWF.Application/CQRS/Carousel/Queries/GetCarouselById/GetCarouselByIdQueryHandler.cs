using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Carousel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Carousel.Queries.GetCarouselById
{
    public class GetCarouselByIdQueryHandler : IRequestHandler<GetCarouselByIdQuery, ServiceResult<CarouselDto>>
    {
        private readonly ICarouselService _carouselService;
        public GetCarouselByIdQueryHandler(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }
        public async Task<ServiceResult<CarouselDto>> Handle(GetCarouselByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _carouselService.GetCarouselById(request.CarouselId);

            return result;
        }
    }
}
