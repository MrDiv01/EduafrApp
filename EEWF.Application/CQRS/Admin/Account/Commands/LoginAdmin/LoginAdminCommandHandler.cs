using EEWF.Application.Core;
using EEWF.Application.Interfaces.Admin;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Admin.Account.Commands.LoginAdmin
{
    public class LoginAdminCommandHandler : IRequestHandler<LoginAdminCommand, ServiceResult<int>>
    {
        private readonly IAccountService _accountService;
        public LoginAdminCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<ServiceResult<int>> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
        {
            var result = await _accountService.Login(request);

            return result;
        }
    }
}
