using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Graduate.Commands.UpdateGraduate
{
    public class UpdateGraduateCommandHandler : IRequestHandler<UpdateGraduateCommand, ServiceResult<int>>
    {
        private readonly IGraduateService _graduateService;
        public UpdateGraduateCommandHandler(IGraduateService graduateService)
        {
            _graduateService = graduateService;
        }
        public async Task<ServiceResult<int>> Handle(UpdateGraduateCommand request, CancellationToken cancellationToken)
        {
            var result = await _graduateService.UpdateGraduate(request);

            return result;
        }
    }
}
