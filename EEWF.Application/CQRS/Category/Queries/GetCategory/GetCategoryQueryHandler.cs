using EEWF.Application.Core;
using EEWF.Application.CQRS.About.Queries.GetAbout;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Category.Queries.GetCategory
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public Task<ServiceResult<List<CategoryDto>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = _categoryService.GetCategorie();
            return result;
        }
    }
}
