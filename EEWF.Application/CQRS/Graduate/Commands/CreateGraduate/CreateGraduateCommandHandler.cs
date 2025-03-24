using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Graduate.Commands.CreateGraduate
{
    public class CreateGraduateCommandHandler : IRequestHandler<CreateGraduateCommand, ServiceResult<int>>
    {
        private readonly IGraduateService _graduateService;
        public CreateGraduateCommandHandler(IGraduateService graduateService)
        {
            _graduateService = graduateService;
        }
        public async Task<ServiceResult<int>> Handle(CreateGraduateCommand request, CancellationToken cancellationToken)
        {
            var result = await _graduateService.CreateGraduate(request);

            return result;
        }
    }
}
