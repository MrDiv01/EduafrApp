using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Admin.Account.Commands.LoginAdmin
{
    public class LoginAdminCommandValidator:AbstractValidator<LoginAdminCommand>
    {
        public LoginAdminCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("The email field cannot be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("The password field cannot be empty.");
        }
    }
}
