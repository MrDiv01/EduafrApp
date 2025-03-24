using EEWF.Application.Core;
using EEWF.Application.CQRS.TeacherCategory.Commands.CreateTeacherCategory;
using EEWF.Application.CQRS.TeacherCategory.Commands.UpdateTeacherCategory;
using EEWF.Domain.DTOs.TeacherCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
	public interface ITeacherCategoryService
	{
		public Task<ServiceResult<List<TeacherCategoryDto>>> GetTeacherCategory();
		Task<ServiceResult<TeacherCategoryDto>> GetTeacherCategoryById(int id);
		Task<ServiceResult<int>> CreateTeacherCategory(CreateTeacherCategoryCommand command);
		Task<ServiceResult<int>> UpdateTeacherCategory(UpdateTeacherCategoryCommand command);
	}
}
