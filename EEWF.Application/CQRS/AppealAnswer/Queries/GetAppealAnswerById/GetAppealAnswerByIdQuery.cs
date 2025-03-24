using EEWF.Application.Core;
using EEWF.Domain.DTOs.AppealAnswer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.AppealAnswer.Queries.GetAppealAnswerById
{
    public class GetAppealAnswerByIdQuery:IRequest<ServiceResult<AppealAnswerDto>>
    {
        public GetAppealAnswerByIdQuery(int appealId)
        {
            AppealId = appealId;
        }
        public int AppealId { get; set; }
        public string Answer { get; set; }
    }
}
