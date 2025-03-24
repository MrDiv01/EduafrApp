using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Graduate.Commands.UpdateGraduate
{
    public class UpdateGraduateCommandValidator:AbstractValidator<UpdateGraduateCommand>
    {
        public UpdateGraduateCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be empty.");
            RuleFor(x => x.Degree).NotEmpty().WithMessage("The degree field cannot be empty.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("The comment field cannot be empty.");
        }
    }
}
