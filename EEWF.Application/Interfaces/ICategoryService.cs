using EEWF.Application.Core;
using EEWF.Application.CQRS.Category.Commands.CreateCategory;
using EEWF.Application.CQRS.Category.Commands.UpdateCategory;
using EEWF.Domain.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResult<List<CategoryDto>>> GetCategorie();
        Task<ServiceResult<CategoryDto>> GetCategorieById(int categoryId);
        Task<ServiceResult<int>> CreateCategory(CreateCategoryCommand command);
        Task<ServiceResult<int>> UpdateCategory(UpdateCategoryCommand command);
    }
}