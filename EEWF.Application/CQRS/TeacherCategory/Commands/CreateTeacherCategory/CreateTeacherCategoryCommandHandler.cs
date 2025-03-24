using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.TeacherCategory.Commands.CreateTeacherCategory
{
    public class CreateTeacherCategoryCommandHandler : IRequestHandler<CreateTeacherCategoryCommand, ServiceResult<int>>
    {
        private readonly ITeacherCategoryService _categoryService;
        public CreateTeacherCategoryCommandHandler(ITeacherCategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public Task<ServiceResult<int>> Handle(CreateTeacherCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = _categoryService.CreateTeacherCategory(request);

            return result;
        }
    }
}
