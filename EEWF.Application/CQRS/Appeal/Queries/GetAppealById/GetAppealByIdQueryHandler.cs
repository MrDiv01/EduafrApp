using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Appeal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Appeal.Queries.GetAppealById
{
    public class GetAppealByIdQueryHandler : IRequestHandler<GetAppealByIdQuery, ServiceResult<AppealDto>>
    {
        private readonly IAppealService _appealService;
        public GetAppealByIdQueryHandler(IAppealService appealService)
        {
            _appealService = appealService;
        }
        public async Task<ServiceResult<AppealDto>> Handle(GetAppealByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _appealService.GetAppealById(request.AppealId);

            return result;
        }
    }
}
