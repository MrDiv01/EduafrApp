using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.TeacherCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.TeacherCategory.Queries.GetTeacherCategory
{
	public class GetTeacherCategoryQueryHandler : IRequestHandler<GetTeacherCategoryQuery, ServiceResult<List<TeacherCategoryDto>>>
	{
		private readonly ITeacherCategoryService _teacherCategoryService;

		public GetTeacherCategoryQueryHandler(ITeacherCategoryService teacherCategoryService )
        {
			_teacherCategoryService = teacherCategoryService;
		}
        public async Task<ServiceResult<List<TeacherCategoryDto>>> Handle(GetTeacherCategoryQuery request, CancellationToken cancellationToken)
		{
			var result = await _teacherCategoryService.GetTeacherCategory();

			return result;
		}
	}
}
