using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Education.Commands.CreateEducation
{
    public class CreateEducationCommandValidator:AbstractValidator<CreateEducationCommand>
    {
        public CreateEducationCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("The description field cannot be empty.");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("The image field cannot be empty.");
            RuleFor(x => x.LevelId).NotEmpty().WithMessage("The level field cannot be empty.");
        }
    }
}
