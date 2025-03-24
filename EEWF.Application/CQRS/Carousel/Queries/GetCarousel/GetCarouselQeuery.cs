using EEWF.Application.Core;
using EEWF.Domain.DTOs.Carousel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Carousel.Queries.GetCarousel
{

    public class GetCarouselQeuery:IRequest<ServiceResult<List<CarouselDto>>>

    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string ButtonText { get; set; }
    }
}
