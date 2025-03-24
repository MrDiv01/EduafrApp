using EEWF.Application.Core;
using EEWF.Application.CQRS.Education.Queries.GetEducation;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Education;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Education.Queries.GetContact
{
    internal class GetEducationQueryHandler : IRequestHandler<GetEducationQuery, ServiceResult<List<EducationDto>>>
    {
        private readonly IEducationService _education;

        public GetEducationQueryHandler(IEducationService education)
        {
            _education = education;
        }
        public async Task<ServiceResult<List<EducationDto>>> Handle(GetEducationQuery request, CancellationToken cancellationToken)
        {
            var result = await _education.GetEducation();
            return result;
        }
    }
}
