using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Teacher.Commands.CreateTeacher
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, ServiceResult<int>>
    {
        private readonly ITeacherService _teacherService;
        public CreateTeacherCommandHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        public async Task<ServiceResult<int>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var result = await _teacherService.CreateTeacher(request);

            return result;
        }
    }
}
