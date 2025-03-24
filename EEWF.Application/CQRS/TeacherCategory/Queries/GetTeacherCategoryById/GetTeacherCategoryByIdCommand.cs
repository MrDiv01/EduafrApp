using EEWF.Application.Core;
using EEWF.Domain.DTOs.TeacherCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.TeacherCategory.Queries.GetTeacherCategoryById
{
    public class GetTeacherCategoryByIdCommand : IRequest<ServiceResult<TeacherCategoryDto>>
    {
        public GetTeacherCategoryByIdCommand(int categoryId)
        {
            TeacherCategoryId = categoryId;
        }

        public int TeacherCategoryId{get;set;}
        public string Name { get; set; }
    }
}
