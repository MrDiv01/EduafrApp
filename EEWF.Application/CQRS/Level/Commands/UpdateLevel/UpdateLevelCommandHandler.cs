using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Commands.UpdateLevel
{
    public class UpdateLevelCommandHandler : IRequestHandler<UpdateLevelCommand, ServiceResult<int>>
    {
        private readonly ILevelService _levelService;
        public UpdateLevelCommandHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }
        public async Task<ServiceResult<int>> Handle(UpdateLevelCommand request, CancellationToken cancellationToken)
        {
            var result = await _levelService.UpdateLevel(request);

            return result;
        }
    }
}
