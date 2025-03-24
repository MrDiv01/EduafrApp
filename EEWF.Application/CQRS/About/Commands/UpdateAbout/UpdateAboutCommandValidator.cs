using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.About.Commands.UpdateAbout
{
    public class UpdateAboutCommandValidator:AbstractValidator<UpdateAboutCommand>
    {
        public UpdateAboutCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The title field cannot be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("The description field cannot be empty.");
        }
    }
}
