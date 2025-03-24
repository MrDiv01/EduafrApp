using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Teacher.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, ServiceResult<int>>
    {
        private readonly ITeacherService _teacherService;
        public UpdateTeacherCommandHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public async Task<ServiceResult<int>> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var result = await _teacherService.UpdateTeacher(request);
            return result;
        }
    }
}
