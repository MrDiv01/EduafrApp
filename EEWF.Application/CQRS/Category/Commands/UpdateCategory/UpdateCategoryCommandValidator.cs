using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("The description field cannot be empty.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("The icon field cannot be empty.");
        }
    }
}
