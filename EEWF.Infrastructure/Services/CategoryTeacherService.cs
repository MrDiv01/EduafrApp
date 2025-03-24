using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.CategoryTeacher;
using EEWF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Services
{
    public class CategoryTeacherService : ICategoryTeacherService
    {
		private readonly ApplicationDbContext _dbContext;

		public CategoryTeacherService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<ServiceResult<CategoryTeacherDto>> GetCategoryTeacher()
        {
			var categoryTeacher = await _dbContext.CategoryTeachers.Select(x => new CategoryTeacherDto
			{
				 TeacherCategoryId = x.TeacherCategoryId,
				  TeacherId = x.TeacherId,
			}).FirstOrDefaultAsync();
			return ServiceResult<CategoryTeacherDto>.OK(categoryTeacher);

		}
    }
}
