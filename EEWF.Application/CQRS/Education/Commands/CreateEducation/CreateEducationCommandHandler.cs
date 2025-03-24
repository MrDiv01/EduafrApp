using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Education.Commands.CreateEducation
{
    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand, ServiceResult<int>>
    {
        private readonly IEducationService _educationService;
        public CreateEducationCommandHandler(IEducationService educationService)
        {
            _educationService = educationService;
        }
        public async Task<ServiceResult<int>> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            var result = await _educationService.CreateEducation(request);

            return result;
        }
    }
}
