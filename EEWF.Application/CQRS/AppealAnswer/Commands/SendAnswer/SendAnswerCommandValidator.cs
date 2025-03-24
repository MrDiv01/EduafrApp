using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.AppealAnswer.Commands.SendAnswer
{
    public class SendAnswerCommandValidator:AbstractValidator<SendAnswerCommand>
    {
        public SendAnswerCommandValidator()
        {
            RuleFor(x => x.Answer).NotEmpty().WithMessage("The answer field cannot be empty.")
                .NotNull();
        }
    }
}
