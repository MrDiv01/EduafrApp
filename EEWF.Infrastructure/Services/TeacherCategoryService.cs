using EEWF.Application.Core;
using EEWF.Application.CQRS.TeacherCategory.Commands.CreateTeacherCategory;
using EEWF.Application.CQRS.TeacherCategory.Commands.UpdateTeacherCategory;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.TeacherCategory;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Services
{
	public class TeacherCategoryService : ITeacherCategoryService
	{
		private readonly ApplicationDbContext _dbContext;

		public TeacherCategoryService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

        public async Task<ServiceResult<int>> CreateTeacherCategory(CreateTeacherCategoryCommand command)
        {
			TeacherCategory category = new TeacherCategory
			{
				Name = command.Name,
			};

			await _dbContext.AddAsync(category);
			await _dbContext.SaveChangesAsync();

			return ServiceResult<int>.OK(category.Id);
        }

        public async Task<ServiceResult<List<TeacherCategoryDto>>> GetTeacherCategory()
		{
			var TeacherCategory = await _dbContext.TeacherCategories.Select(x => new TeacherCategoryDto
			{
				TeacherCategoryId = x.Id,
				Name = x.Name,
			}).ToListAsync();
			return ServiceResult<List<TeacherCategoryDto>>.OK(TeacherCategory);
		}

        public async Task<ServiceResult<TeacherCategoryDto>> GetTeacherCategoryById(int id)
        {
			var result = await _dbContext.TeacherCategories.Where(x => x.Id == id).Select(x => new TeacherCategoryDto
			{
				TeacherCategoryId = x.Id,
				Name = x.Name,
			}).FirstOrDefaultAsync();

			return ServiceResult<TeacherCategoryDto>.OK(result);
        }

        public async Task<ServiceResult<int>> UpdateTeacherCategory(UpdateTeacherCategoryCommand command)
        {
			var existCategory = await _dbContext.TeacherCategories.Where(x => x.Id == command.TeacherCategoryId).FirstOrDefaultAsync();

			existCategory.Name = command.Name;

			await _dbContext.SaveChangesAsync();
			return ServiceResult<int>.OK(existCategory.Id);
        }
    }
}
