using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.TeacherCategory.Commands.UpdateTeacherCategory
{
    public class UpdateTeacherCategoryCommandHandler : IRequestHandler<UpdateTeacherCategoryCommand, ServiceResult<int>>
    {
        private readonly ITeacherCategoryService _categoryService;
        public UpdateTeacherCategoryCommandHandler(ITeacherCategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ServiceResult<int>> Handle(UpdateTeacherCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.UpdateTeacherCategory(request);

            return result;
        }
    }
}
