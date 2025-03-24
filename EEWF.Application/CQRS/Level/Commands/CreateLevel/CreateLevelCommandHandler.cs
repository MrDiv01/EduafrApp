using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Commands.CreateLevel
{
    public class CreateLevelCommandHandler : IRequestHandler<CreateLevelCommand, ServiceResult<int>>
    {
        private readonly ILevelService _levelService;
        public CreateLevelCommandHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }
        public async Task<ServiceResult<int>> Handle(CreateLevelCommand request, CancellationToken cancellationToken)
        {
            var result = await _levelService.CreateLevel(request);

            return result;
        }
    }
}
