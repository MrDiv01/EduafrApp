using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Commands.CreateLevel
{
    public class CreateLevelCommandValidator:AbstractValidator<CreateLevelCommand>
    {
        public CreateLevelCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be empty.");
        }
    }
}
