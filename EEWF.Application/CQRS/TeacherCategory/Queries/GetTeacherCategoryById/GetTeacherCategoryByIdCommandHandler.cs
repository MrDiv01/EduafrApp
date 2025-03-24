using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.TeacherCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.TeacherCategory.Queries.GetTeacherCategoryById
{
    public class GetTeacherCategoryByIdCommandHandler : IRequestHandler<GetTeacherCategoryByIdCommand, ServiceResult<TeacherCategoryDto>>
    {
        private readonly ITeacherCategoryService _categoryService;
        public GetTeacherCategoryByIdCommandHandler(ITeacherCategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public Task<ServiceResult<TeacherCategoryDto>> Handle(GetTeacherCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var result = _categoryService.GetTeacherCategoryById(request.TeacherCategoryId);

            return result;
        }
    }
}
