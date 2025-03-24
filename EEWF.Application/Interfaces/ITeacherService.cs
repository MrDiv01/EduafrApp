using EEWF.Application.Core;
using EEWF.Application.CQRS.Teacher.Commands.CreateTeacher;
using EEWF.Application.CQRS.Teacher.Commands.UpdateTeacher;
using EEWF.Domain.DTOs.Teacher;
using EEWF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
	public interface ITeacherService
	{
		public Task<ServiceResult<List<TeacherDto>>> GetTeacher();
		Task<ServiceResult<TeacherDto>> GetTeacherById(int teacherId);
		Task<ServiceResult<int>> CreateTeacher(CreateTeacherCommand command);
		Task<ServiceResult<int>> UpdateTeacher(UpdateTeacherCommand command);
    }
}
