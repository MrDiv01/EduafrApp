using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Appeal.Commands
{
    public class SendAppealCommandHandler : IRequestHandler<SendAppealCommand, ServiceResult<int>>
    {
        private readonly IAppealService _appealService;
        public SendAppealCommandHandler(IAppealService appealService)
        {
            _appealService = appealService;
        }
        public async Task<ServiceResult<int>> Handle(SendAppealCommand request, CancellationToken cancellationToken)
        {
            var result = await _appealService.SendAppeal(request);

            return result;
        }
    }
}
