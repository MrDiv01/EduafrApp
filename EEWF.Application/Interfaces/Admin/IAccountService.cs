using EEWF.Application.Core;
using EEWF.Application.CQRS.Admin.Account.Commands.LoginAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces.Admin
{
    public interface IAccountService
    {
        Task<ServiceResult<int>> Login(LoginAdminCommand command);
    }
}
