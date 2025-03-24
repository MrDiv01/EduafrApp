using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Appeal.Commands
{
    public class SendAppealCommandValidator:AbstractValidator<SendAppealCommand>
    {
        public SendAppealCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be empty.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("The surname field cannot be empty.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("The email field cannot be empty.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("The subject field cannot be empty.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("The message field cannot be empty.");
        }
    }
}
