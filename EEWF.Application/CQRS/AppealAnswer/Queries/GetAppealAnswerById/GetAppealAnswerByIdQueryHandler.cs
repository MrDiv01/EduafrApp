using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.AppealAnswer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.AppealAnswer.Queries.GetAppealAnswerById
{
    public class GetAppealAnswerByIdQueryHandler : IRequestHandler<GetAppealAnswerByIdQuery, ServiceResult<AppealAnswerDto>>
    {
        private readonly IAppealAnswerService _service;
        public GetAppealAnswerByIdQueryHandler(IAppealAnswerService service)
        {
            _service = service;
        }
        public async Task<ServiceResult<AppealAnswerDto>> Handle(GetAppealAnswerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAppealAnswerById(request.AppealId);

            return result;
        }
    }
}
