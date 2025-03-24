using EEWF.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Carousel.Commands.UpdateCarousel
{
    public class UpdateCarouselCommand:IRequest<ServiceResult<int>>
    {
        public UpdateCarouselCommand(int carouselId, string title, string description, string url, string buttonText, IFormFile imageFile)
        {
            CarouselId = carouselId;
            Title = title;
            Description = description;
            Url = url;
            ButtonText = buttonText;
            ImageFile = imageFile;
        }
        public int CarouselId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string ButtonText { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}