using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Commands.UpdateLevel
{
    public class UpdateLevelCommandValidator:AbstractValidator<UpdateLevelCommand>
    {
        public UpdateLevelCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be empty.");
        }
    }
}
