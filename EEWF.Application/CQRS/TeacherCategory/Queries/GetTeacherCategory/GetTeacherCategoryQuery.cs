using EEWF.Application.Core;
using EEWF.Domain.DTOs.TeacherCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.TeacherCategory.Queries.GetTeacherCategory
{
	public class GetTeacherCategoryQuery:IRequest<ServiceResult<List<TeacherCategoryDto>>>
	{
		public string Name { get; set; }

	}
}
