using EEWF.Application.Core;
using EEWF.Domain.DTOs.CategoryTeacher;
using EEWF.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.CategoryTeacher.Queries.GetCategoryTeacher
{
    public class GetCategoryTeacherQuery:IRequest<ServiceResult<CategoryTeacherDto>>
    {
        public int TeacherId { get; set; }
        public int TeacherCategoryId { get; set; }
    }
}
