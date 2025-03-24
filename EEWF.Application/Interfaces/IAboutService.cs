using EEWF.Application.Core;
using EEWF.Application.CQRS.About.Commands.UpdateAbout;
using EEWF.Domain.DTOs.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
    public interface IAboutService
    {
        Task<ServiceResult<AboutDto>> GetAbout();   
        Task<ServiceResult<int>> UpdateAbout(UpdateAboutCommand command);
        Task<ServiceResult<AboutDto>> GetAboutById(int aboutId);
    }
}
