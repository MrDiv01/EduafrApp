using EEWF.Application.Core;
using EEWF.Application.CQRS.Graduate.Commands.CreateGraduate;
using EEWF.Application.CQRS.Graduate.Commands.UpdateGraduate;
using EEWF.Domain.DTOs.Graduate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
	public interface IGraduateService
	{
		Task<ServiceResult<List<GraduateDto>>> GetGraduate();
		Task<ServiceResult<GraduateDto>> GetGraduateById(int id);
		Task<ServiceResult<int>> CreateGraduate(CreateGraduateCommand command);
		Task<ServiceResult<int>> UpdateGraduate(UpdateGraduateCommand command);
	}
}
