using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Teacher.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandValidator:AbstractValidator<UpdateTeacherCommand>
    {
        public UpdateTeacherCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be empty.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("The surname field cannot be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("The description field cannot be empty.");
        }
    }
}
