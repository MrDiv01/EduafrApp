using EEWF.Application.Core;

using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Level;

using EEWF.Application.CQRS.Level.Commands.CreateLevel;
using EEWF.Application.CQRS.Level.Commands.UpdateLevel;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Level;
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
    public class LevelService : ILevelService
    {

        private readonly ApplicationDbContext _context;
        public LevelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<int>> CreateLevel(CreateLevelCommand command)
        {
            Level level = new Level
            {
                Name = command.Name
            };

            await _context.Levels.AddAsync(level);
            await _context.SaveChangesAsync();

            return ServiceResult<int>.OK(level.Id);
        }

        public async Task<ServiceResult<List<LevelDto>>> GetLevel()
        {
            var levels = await _context.Levels.Select(x => new LevelDto
            {
                LevelId = x.Id,
                Name = x.Name
            }).ToListAsync();

            return ServiceResult<List<LevelDto>>.OK(levels);
        }

        public async Task<ServiceResult<LevelDto>> GetLevelById(int id)
        {
            var result = await _context.Levels.Where(x => x.Id == id).Select(x => new LevelDto
            {
                Name = x.Name,
                LevelId = x.Id,
            }).FirstOrDefaultAsync();

            return ServiceResult<LevelDto>.OK(result);
        }

        public async Task<ServiceResult<int>> UpdateLevel(UpdateLevelCommand command)
        {
            var existLevel = await _context.Levels.Where(x => x.Id == command.LevelId).FirstOrDefaultAsync();

            existLevel.Name = command.Name;

            await _context.SaveChangesAsync();
            return ServiceResult<int>.OK(existLevel.Id);

        }
    }
}
