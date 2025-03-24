using EEWF.Application.Core;
using EEWF.Application.CQRS.AppealAnswer.Commands.SendAnswer;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.AppealAnswer;
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
    public class AppealAnswerService : IAppealAnswerService
    {
        private readonly ApplicationDbContext _context;

        public AppealAnswerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<AppealAnswerDto>> GetAppealAnswerById(int appealId)
        {
            var result = await _context.AppealAnswers.Where(x => x.AppealId == appealId).Select(x => new AppealAnswerDto
            {
                Answer = x.Answer,
                AppealId = x.AppealId,
            }).FirstOrDefaultAsync();

            return ServiceResult<AppealAnswerDto>.OK(result);
        }

        public async Task<ServiceResult<int>> SendAnswer(SendAnswerCommand command)
        {
            AppealAnswer answer = new AppealAnswer
            {
                Answer = command.Answer,
                AppealId = command.AppealId,
            };

            var appeal = await _context.Appeals.Where(x => x.Id == command.AppealId).FirstOrDefaultAsync();

            appeal.IsAnswer = true;

            await _context.AppealAnswers.AddAsync(answer);
            await _context.SaveChangesAsync();

            return ServiceResult<int>.OK(answer.Id);
        }
    }
}
