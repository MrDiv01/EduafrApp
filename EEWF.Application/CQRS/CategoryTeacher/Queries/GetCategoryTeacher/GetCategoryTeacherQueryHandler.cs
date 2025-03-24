using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.CategoryTeacher;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.CategoryTeacher.Queries.GetCategoryTeacher
{
    public class GetCategoryTeacherQueryHandler : IRequestHandler<GetCategoryTeacherQuery, ServiceResult<CategoryTeacherDto>>
    {
        private readonly ICategoryTeacherService _categoryTeacherService;

        public GetCategoryTeacherQueryHandler(ICategoryTeacherService categoryTeacherService)
        {
            _categoryTeacherService = categoryTeacherService;
        }
        public Task<ServiceResult<CategoryTeacherDto>> Handle(GetCategoryTeacherQuery request, CancellationToken cancellationToken)
        {
            var result = _categoryTeacherService.GetCategoryTeacher();
            return result;
        }
    }
}
