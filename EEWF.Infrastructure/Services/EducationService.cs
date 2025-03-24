using EEWF.Application.Core;
using EEWF.Application.CQRS.Education.Commands.CreateEducation;
using EEWF.Application.CQRS.Education.Commands.UpdateEducation;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Education;
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
    public class EducationService : IEducationService 
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public EducationService(ApplicationDbContext applicationDbContext, IFileService fileService, IWebHostEnvironment env)
        {
            _applicationDbContext = applicationDbContext;
            _fileService = fileService;
            _env = env;
        }

        public async Task<ServiceResult<int>> CreateEducation(CreateEducationCommand command)
        {
            Education education = new Education
            {
                Name = command.Name,
                Description = command.Description,
                LevelId = command.LevelId
            };

            if(command.ImageFile != null)
            {
                education.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/education", command.ImageFile);
            }

            await _applicationDbContext.Educations.AddAsync(education);
            await _applicationDbContext.SaveChangesAsync();

            return ServiceResult<int>.OK(education.Id);
        }

        public async Task<ServiceResult<List<EducationDto>>> GetEducation()
        {
            List<EducationDto> educations = await _applicationDbContext.Educations.Select(x => new EducationDto
            {

               
                Description =x.Description.Substring(0,173) + ". . .",

                EducationId = x.Id,
                

                Name = x.Name,
                Image = x.Image,
            }).ToListAsync();
            return ServiceResult<List<EducationDto>>.OK(educations);
        }


        public async Task<ServiceResult<EducationDto>> GetEducationById(int educationId)
        {
            var result = await _applicationDbContext.Educations.Where(x => x.Id == educationId).Select(x => new EducationDto
            {
                Name = x.Name,
                Image = x.Image,
                Description = x.Description,
                EducationId = x.Id,
                
            }).FirstOrDefaultAsync();

            return ServiceResult<EducationDto>.OK(result);
        }

        public async Task<ServiceResult<List<EducationDto>>> GetEducationByLevelId(int levelId)
        {
            var result = await _applicationDbContext.Educations.Where(x => x.LevelId == levelId).Select(x => new EducationDto
            {
                Name = x.Name,
                Image = x.Image,
                Description = x.Description,
                EducationId = x.Id,
            }).ToListAsync();
            return ServiceResult<List<EducationDto>>.OK(result);
        }

        public async Task<ServiceResult<int>> UpdateEducation(UpdateEducationCommand command)
        {
            var existEducation = await _applicationDbContext.Educations.Where(x => x.Id == command.EducationId).FirstOrDefaultAsync();

            if (existEducation != null)
            {
                existEducation.Name = command.Name;
                existEducation.Description = command.Description;
                if(command.ImageFile != null)
                {
                    _fileService.DeleteImage(_env.WebRootPath, "uploads/education", existEducation.Image);
                    existEducation.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/education", command.ImageFile);
                }
            }

            await _applicationDbContext.SaveChangesAsync();

            return ServiceResult<int>.OK(existEducation.Id);
        }
    }

}
