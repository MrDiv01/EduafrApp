using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ServiceResult<int>>
    {
        private readonly ICategoryService _categoryService;
        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ServiceResult<int>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.UpdateCategory(request);

            return result;
        }
    }
}
