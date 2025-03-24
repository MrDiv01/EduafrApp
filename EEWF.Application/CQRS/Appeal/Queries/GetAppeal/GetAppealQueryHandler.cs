using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Appeal;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Appeal.Queries.GetAppeal
{
    public class GetAppealQueryHandler : IRequestHandler<GetAppealQuery, ServiceResult<List<AppealDto>>>
    {
        private readonly IAppealService _appealService;

        public GetAppealQueryHandler(IAppealService appealService)
        {
            _appealService = appealService;
        }
        public async Task<ServiceResult<List<AppealDto>>> Handle(GetAppealQuery request, CancellationToken cancellationToken)
        {
            var result =await  _appealService.GetAppeal();
            return result;
        }
    }
}
