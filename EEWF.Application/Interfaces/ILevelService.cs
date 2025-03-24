using EEWF.Application.Core;

using EEWF.Application.CQRS.Level.Commands.CreateLevel;
using EEWF.Application.CQRS.Level.Commands.UpdateLevel;

using EEWF.Domain.DTOs.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
    public interface ILevelService
    {
        Task<ServiceResult<List<LevelDto>>> GetLevel();

        Task<ServiceResult<LevelDto>> GetLevelById(int id);
        Task<ServiceResult<int>> CreateLevel(CreateLevelCommand command);
        Task<ServiceResult<int>> UpdateLevel(UpdateLevelCommand command);

    }
}
