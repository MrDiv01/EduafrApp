using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Graduate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Graduate.Queries.GetGraduate
{
	public class GetGraduateQueryHandler : IRequestHandler<GetGraduateQuery, ServiceResult<List<GraduateDto>>>
	{
		private readonly IGraduateService _graduate;

		public GetGraduateQueryHandler(IGraduateService graduate)
		{
			_graduate = graduate;
		}
		public async Task<ServiceResult<List<GraduateDto>>> Handle(GetGraduateQuery request, CancellationToken cancellationToken)
		{
			var result = await _graduate.GetGraduate();
			return result;
		}
	}
}
