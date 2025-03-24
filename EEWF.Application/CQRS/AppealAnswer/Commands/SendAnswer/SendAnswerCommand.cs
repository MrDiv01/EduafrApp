using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.AppealAnswer.Commands.SendAnswer
{
    public class SendAnswerCommand:IRequest<ServiceResult<int>>
    {
        public SendAnswerCommand(string answer, string email, int appealId)
        {
            Answer = answer;
            Email = email;
            AppealId = appealId;
        }
        public string Answer { get; set; }
        public string Email { get; set; }
        public int AppealId { get; set; }
    }
}
