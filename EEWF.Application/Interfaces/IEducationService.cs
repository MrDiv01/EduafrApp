using EEWF.Application.Core;
using EEWF.Application.CQRS.Education.Commands.CreateEducation;
using EEWF.Application.CQRS.Education.Commands.UpdateEducation;
using EEWF.Domain.DTOs.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
    public interface IEducationService
    {
        Task<ServiceResult<List<EducationDto>>> GetEducation();

        Task<ServiceResult<EducationDto>> GetEducationById(int educationId);
        Task<ServiceResult<List<EducationDto>>> GetEducationByLevelId(int educationId);

        Task<ServiceResult<int>> CreateEducation(CreateEducationCommand command);
        Task<ServiceResult<int>> UpdateEducation(UpdateEducationCommand command);

    }
}
