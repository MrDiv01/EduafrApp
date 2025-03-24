using EEWF.Application.Core;
using EEWF.Application.CQRS.Appeal.Commands;
using EEWF.Domain.DTOs.Appeal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
    public interface IAppealService
    {
        Task<ServiceResult<List<AppealDto>>> GetAppeal();
        Task<ServiceResult<AppealDto>> GetAppealById(int appealId);
        Task<ServiceResult<int>> SendAppeal(SendAppealCommand command);
    }
}
