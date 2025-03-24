using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Teacher;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Teacher.Queries.GetTeacher
{
	internal class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, ServiceResult<List<TeacherDto>>>
	{
		private readonly ITeacherService _teacherService;

		public GetTeacherQueryHandler(ITeacherService teacherService)
        {
			_teacherService = teacherService;
		}

		public async Task<ServiceResult<List<TeacherDto>>> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
		{
			var result = await _teacherService.GetTeacher();
			return result;
		}
	}
}
