using EEWF.Application.Core;
using EEWF.Domain.DTOs.Teacher;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Teacher.Queries.GetTeacherById
{
    public class GetTeacherByIdQuery:IRequest<ServiceResult<TeacherDto>>
    {
        public GetTeacherByIdQuery(int teacherId)
        {
            TeacherId = teacherId;
        }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
