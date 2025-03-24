using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Graduate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Graduate.Queries.GetGraduateById
{
    public class GetGraduateByIdQueryHandler : IRequestHandler<GetGraduateByIdQuery, ServiceResult<GraduateDto>>
    {
        private readonly IGraduateService _graduateService;
        public GetGraduateByIdQueryHandler(IGraduateService graduateService)
        {
            _graduateService = graduateService;
        }
        public async Task<ServiceResult<GraduateDto>> Handle(GetGraduateByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _graduateService.GetGraduateById(request.GraduateId);

            return result;
        }
    }
}
