using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Contact.Command.UpdateContact
{
    public class UpdateContactCommandValidator:AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(x => x.Location).NotEmpty().WithMessage("The location field cannot be empty.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("The phone field cannot be empty.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("The mail field cannot be empty.");
        }
    }
}
