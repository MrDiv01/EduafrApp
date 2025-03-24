using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResult<int>>
    {
        private readonly ICategoryService _categoryService;
        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ServiceResult<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.CreateCategory(request);

            return result;
        }
    }
}
