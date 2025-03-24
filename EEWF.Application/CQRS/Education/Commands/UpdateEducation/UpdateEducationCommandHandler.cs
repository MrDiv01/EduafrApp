using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Education.Commands.UpdateEducation
{
    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand, ServiceResult<int>>
    {
        private readonly IEducationService _educationService;
        public UpdateEducationCommandHandler(IEducationService educationService)
        {
            _educationService = educationService;
        }
        public async Task<ServiceResult<int>> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var result = await _educationService.UpdateEducation(request);

            return result;
        }
    }
}
