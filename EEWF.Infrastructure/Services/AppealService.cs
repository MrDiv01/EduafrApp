using EEWF.Application.Core;
using EEWF.Application.CQRS.Appeal.Commands;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Appeal;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Services
{
    public class AppealService : IAppealService
    {
        private readonly ApplicationDbContext _context;
        public AppealService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResult<List<AppealDto>>> GetAppeal()
        {
            var result = await _context.Appeals.Select(x => new AppealDto
            {
                AppealId = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Subject = x.Subject,
                Message = x.Message,
                IsAnswer = x.IsAnswer,
                CreateAt = x.CreateAt,
            }).OrderByDescending(x => x.IsAnswer).Reverse().ToListAsync();

            return ServiceResult<List<AppealDto>>.OK(result);
        }

        public async Task<ServiceResult<AppealDto>> GetAppealById(int appealId)
        {
            var result = await _context.Appeals.Where(x => x.Id == appealId).Select(x => new AppealDto
            {
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Subject = x.Subject,
                Message = x.Message,
                IsAnswer = x.IsAnswer,
            }).FirstOrDefaultAsync();

            return ServiceResult<AppealDto>.OK(result);
        }

        public async Task<ServiceResult<int>> SendAppeal(SendAppealCommand command)
        {
            Appeal appeal = new Appeal
            {
                Name = command.Name,
                Surname = command.Surname,
                Email = command.Email,
                Subject = command.Subject,
                Message = command.Message,
            };

            await _context.Appeals.AddAsync(appeal);
            await _context.SaveChangesAsync();

            return ServiceResult<int>.OK(appeal.Id);
        }
    }
}
