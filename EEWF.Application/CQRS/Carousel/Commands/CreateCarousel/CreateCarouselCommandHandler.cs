using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Carousel.Commands.CreateCarousel
{
    public class CreateCarouselCommandHandler : IRequestHandler<CreateCarouselCommand, ServiceResult<int>>
    {
        private readonly ICarouselService _carouselService;
        public CreateCarouselCommandHandler(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }
        public async Task<ServiceResult<int>> Handle(CreateCarouselCommand request, CancellationToken cancellationToken)
        {
            var result = await _carouselService.CreateCarousel(request);

            return result;
        }
    }
}
