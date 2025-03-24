using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.AppealAnswer.Commands.SendAnswer
{
    public class SendAnswerCommandHandler : IRequestHandler<SendAnswerCommand, ServiceResult<int>>
    {
        private readonly IAppealAnswerService _answerService;
        public SendAnswerCommandHandler(IAppealAnswerService answerService)
        {
            _answerService = answerService;
        }
        public async Task<ServiceResult<int>> Handle(SendAnswerCommand request, CancellationToken cancellationToken)
        {
            var result = await _answerService.SendAnswer(request);

            return result;
        }
    }
}
