using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Education;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Education.Queries.GetEducationByLevelId
{
    internal class GetEducationByLevelIdQueryHandler:IRequestHandler<GetEducationByLevelIdQuery,ServiceResult<List<EducationDto>>>
    {
        private readonly IEducationService _educationService;
        public GetEducationByLevelIdQueryHandler(IEducationService educationService)
        {
            _educationService = educationService;
        }
        public async Task<ServiceResult<List<EducationDto>>> Handle(GetEducationByLevelIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _educationService.GetEducationByLevelId(request.LevelId);
            return result;
        }
    }
}
