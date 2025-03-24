using EEWF.Application.Core;
using EEWF.Application.CQRS.Graduate.Commands.CreateGraduate;
using EEWF.Application.CQRS.Graduate.Commands.UpdateGraduate;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Graduate;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Services
{
	public class GraduateService : IGraduateService
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IFileService _fileService;
		private readonly IWebHostEnvironment _env;
		public GraduateService(ApplicationDbContext dbContext, IWebHostEnvironment env, IFileService fileService)
		{
			_dbContext = dbContext;
			_env = env;
			_fileService = fileService;
		}

        public async Task<ServiceResult<int>> CreateGraduate(CreateGraduateCommand command)
        {
			Graduate graduate = new Graduate
			{
				Name = command.Name,
				Degree = command.Degree,
				Comment = command.Comment
			};

			if(command.ImageFile != null)
			{
				graduate.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/graduate", command.ImageFile);
			}

			await _dbContext.Graduates.AddAsync(graduate);
			await _dbContext.SaveChangesAsync();

			return ServiceResult<int>.OK(graduate.Id);
        }

        public async Task<ServiceResult<List<GraduateDto>>> GetGraduate()
		{
			List<GraduateDto> Graduate = await _dbContext.Graduates.Select(x => new GraduateDto
			{
				GraduateId = x.Id,
				Image = x.Image,
				Name = x.Name,
				Degree = x.Degree,
				Comment = x.Comment
			}).ToListAsync();
			return ServiceResult<List<GraduateDto>>.OK(Graduate);
		}

        public async Task<ServiceResult<GraduateDto>> GetGraduateById(int id)
        {
            var graduate = await _dbContext.Graduates.Where(x => x.Id == id).Select(x => new GraduateDto
            {
                GraduateId = x.Id,
                Image = x.Image,
                Name = x.Name,
                Degree = x.Degree,
                Comment = x.Comment
            }).FirstOrDefaultAsync();

			return ServiceResult<GraduateDto>.OK(graduate);

        }

        public async Task<ServiceResult<int>> UpdateGraduate(UpdateGraduateCommand command)
        {
			var existGraduate = await _dbContext.Graduates.Where(x => x.Id == command.GraduateId).FirstOrDefaultAsync();

			existGraduate.Name = command.Name;
			existGraduate.Comment = command.Comment;
			existGraduate.Degree = command.Degree;

			if(command.ImageFile != null)
			{
				_fileService.DeleteImage(_env.WebRootPath, "uploads/graduate", existGraduate.Image);
				existGraduate.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/graduate", command.ImageFile);
			}

			await _dbContext.SaveChangesAsync();

			return ServiceResult<int>.OK(existGraduate.Id);
        }
    }
}
