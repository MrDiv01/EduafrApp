using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Teacher;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Teacher.Queries.GetTeacherById
{
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, ServiceResult<TeacherDto>>
    {
        private readonly ITeacherService _teacherService;
        public GetTeacherByIdQueryHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public async Task<ServiceResult<TeacherDto>> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _teacherService.GetTeacherById(request.TeacherId);

            return result;
        }
    }
}
