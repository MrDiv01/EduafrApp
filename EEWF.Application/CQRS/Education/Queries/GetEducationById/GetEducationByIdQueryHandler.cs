using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Education;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Education.Queries.GetEducationById
{

	public class GetEducationByIdQueryHandler : IRequestHandler<GetEducationByIdQuery, ServiceResult<EducationDto>>
	{
		private readonly IEducationService _educationService;

		public GetEducationByIdQueryHandler(IEducationService educationService)
        {
			_educationService = educationService;
		}
        public async Task<ServiceResult<EducationDto>> Handle(GetEducationByIdQuery request, CancellationToken cancellationToken)
		{
			var result =await _educationService.GetEducationById(request.EducationId);
			return result;
		}
	}

}
