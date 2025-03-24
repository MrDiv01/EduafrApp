using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Admin.Account.Commands.LoginAdmin
{
    public class LoginAdminCommand:IRequest<ServiceResult<int>>
    {
        public LoginAdminCommand(string email , string password)
        {
            Email = email;
            Password = password;
        }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
