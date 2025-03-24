using EEWF.Application.CQRS.Admin.Account.Commands.LoginAdmin;
using EEWF.Domain.DTOs.Admin;
using EEWF.Domain.Entities;
using EEWF.Domain.Enum;
using EEWF.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpContext _httpContext;
        private readonly IMediator _mediator;
        public AccountController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
            _mediator = mediator;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDto user)
        {
            var result = await _mediator.Send(new LoginAdminCommand(user.Email, user.Password));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(user);
            }

            return RedirectToAction("Index", "DashBoard");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("login", "Account");
        }

        
    }
}
