using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Carousel.Commands.UpdateCarousel
{
    public class UpdateCarouselCommandHandler : IRequestHandler<UpdateCarouselCommand, ServiceResult<int>>
    {
        private readonly ICarouselService _carouselService;
        public UpdateCarouselCommandHandler(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }
        public async Task<ServiceResult<int>> Handle(UpdateCarouselCommand request, CancellationToken cancellationToken)
        {
            var result = await _carouselService.UpdateCarousel(request);

            return result;
        }
    }
}
