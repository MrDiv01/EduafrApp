using EEWF.Application.Core;
using EEWF.Application.CQRS.Admin.Account.Commands.LoginAdmin;
using EEWF.Application.Interfaces.Admin;
using EEWF.Domain.Enum;
using EEWF.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Services.Admin
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpContext _httpContext;
        public AccountService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
        }
        public async Task<ServiceResult<int>> Login(LoginAdminCommand command)
        {
            var admin = await _context.Users.Where(x => x.Email == command.Email).FirstOrDefaultAsync();

            //if(admin == null)
            //{
            //    return ServiceResult<int>.ERROR("", "Hesab tapilmadi");
            //}

            //if (admin.UserRoleId != (int)UserRoleEnum.Admin)
            //{
            //    return ServiceResult<int>.ERROR("", "Hesab tapilmadi");
            //}

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(command.Password);
                var hash = SHA256.HashData(buffer);
                for(int i = 0; i < hash.Length; i++)
                {
                    hash[i] = (byte)~hash[i];
                    Console.Write(hash[i]);
                }
                if (!admin.Password.SequenceEqual(hash))
                {
                    return ServiceResult<int>.ERROR("Password", "Sifre yalnisdir");
                }

            };

            var claims = new List<Claim>
                {
                new Claim("Email", admin.Email),
                new Claim("Name", admin.Name),
                new Claim("Id",admin.Id.ToString()),
                new Claim("RoleId",admin.UserRoleId.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
            };

            await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            _httpContext.Session.Remove("loginRequest");

            return ServiceResult<int>.OK(admin.Id);
        }
    }
}
