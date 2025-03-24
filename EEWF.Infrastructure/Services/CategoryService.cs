using EEWF.Application.Core;
using EEWF.Application.CQRS.Category.Commands.CreateCategory;
using EEWF.Application.CQRS.Category.Commands.UpdateCategory;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Category;
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
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResult<int>> CreateCategory(CreateCategoryCommand command)
        {
            Category category = new Category
            {
                Name = command.Name,
                Icon = command.Icon,
                Description = command.Description,
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return ServiceResult<int>.OK(category.Id);
        }

        public async Task<ServiceResult<List<CategoryDto>>> GetCategorie()
        {
            var result = await _context.Categories.Select(x => new CategoryDto
            {
                CategoryId = x.Id,
                Name = x.Name,
                Icon = x.Icon,
                Description = x.Description,
            }).ToListAsync();

            return ServiceResult<List<CategoryDto>>.OK(result);
        }

        public async Task<ServiceResult<CategoryDto>> GetCategorieById(int categoryId)
        {
            var category = await _context.Categories.Where(x => x.Id == categoryId).Select(x => new CategoryDto
            {
                CategoryId = x.Id,
                Name = x.Name,
                Icon = x.Icon,
                Description= x.Description,
            }).FirstOrDefaultAsync();

            return ServiceResult<CategoryDto>.OK(category);
        }

        public async Task<ServiceResult<int>> UpdateCategory(UpdateCategoryCommand command)
        {
            var existCategory = await _context.Categories.Where(x => x.Id == command.CategoryId).FirstOrDefaultAsync();

            existCategory.Name = command.Name;
            existCategory.Icon = command.Icon;
            existCategory.Description = command.Description;

            await _context.SaveChangesAsync();

            return ServiceResult<int>.OK(existCategory.Id);
        }
    }
}
