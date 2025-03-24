using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Carousel.Commands.UpdateCarousel
{
    public class UpdateCarouselCommandValidator:AbstractValidator<UpdateCarouselCommand>
    {
        public UpdateCarouselCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The title field cannot be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("The description field cannot be empty.");
            RuleFor(x => x.ButtonText).NotEmpty().WithMessage("The text field cannot be empty.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("The url field cannot be empty.");
        }
    }
}
