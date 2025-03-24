using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.TeacherCategory.Commands.CreateTeacherCategory
{
    public class CreateTeacherCategoryCommandValidator:AbstractValidator<CreateTeacherCategoryCommand>
    {
        public CreateTeacherCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be empty.");
        }
    }
}
