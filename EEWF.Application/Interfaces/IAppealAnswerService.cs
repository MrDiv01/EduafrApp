using EEWF.Application.Core;
using EEWF.Application.CQRS.AppealAnswer.Commands.SendAnswer;
using EEWF.Domain.DTOs.AppealAnswer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
    public interface IAppealAnswerService
    {
        Task<ServiceResult<int>> SendAnswer(SendAnswerCommand command);
        Task<ServiceResult<AppealAnswerDto>> GetAppealAnswerById(int appealId);
    }
}
