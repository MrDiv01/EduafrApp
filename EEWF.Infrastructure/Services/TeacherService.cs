using EEWF.Application.Core;
using EEWF.Application.CQRS.Teacher.Commands.CreateTeacher;
using EEWF.Application.CQRS.Teacher.Commands.UpdateTeacher;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Teacher;
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
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public TeacherService(ApplicationDbContext dbContext, IFileService fileService, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _fileService = fileService;
            _env = env;
        }

        public async Task<ServiceResult<int>> CreateTeacher(CreateTeacherCommand command)
        {
            Teacher teacher = new Teacher
            {
                Name = command.Name,
                Surname = command.Surname,
                Description = command.Description,
            };

            if (command.ImageFile != null)
            {
                teacher.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/teacher", command.ImageFile);
            }

            await _dbContext.Teachers.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();

            CategoryTeacher categoryTeacher = new CategoryTeacher
            {
                TeacherId = teacher.Id,
                TeacherCategoryId = command.TeacherCategoryId,
            };

            await _dbContext.CategoryTeachers.AddAsync(categoryTeacher);

            

            
            await _dbContext.SaveChangesAsync();

            return ServiceResult<int>.OK(teacher.Id);
        }

        public async Task<ServiceResult<List<TeacherDto>>> GetTeacher()
        {
            var teacher = await _dbContext.Teachers.Include(c => c.CategoryTeachers).
                                                        Select(x => new TeacherDto
                                                        {
                                                            TeacherId = x.Id,
                                                            Description = x.Description,
                                                            Name = x.Name,
                                                            Surname = x.Surname,
                                                            Image = x.Image,
                                                            category = x.CategoryTeachers.FirstOrDefault(y=>y.TeacherId == x.Id).TeacherCategory.Name
                                                        }).ToListAsync();

            return ServiceResult<List<TeacherDto>>.OK(teacher);
        }

        public async Task<ServiceResult<TeacherDto>> GetTeacherById(int teacherId)
        {
            var teacher = await _dbContext.Teachers.Where(x => x.Id == teacherId).Select(x => new TeacherDto
            {
                TeacherId = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Description = x.Description,
                Image = x.Image,
            }).FirstOrDefaultAsync();

            return ServiceResult<TeacherDto>.OK(teacher);
        }

        public async Task<ServiceResult<int>> UpdateTeacher(UpdateTeacherCommand command)
        {
            var existTeacher = await _dbContext.Teachers.Where(x => x.Id == command.TeacherCategoryId).FirstOrDefaultAsync();

            existTeacher.Name = command.Name;
            existTeacher.Surname = command.Surname;
            existTeacher.Description = command.Description;
            
            if(command.ImageFile != null)
            {
               await _fileService.DeleteImage(_env.WebRootPath, "uploads/teacher", existTeacher.Image);
                existTeacher.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/teacher", command.ImageFile);
            }

            await _dbContext.SaveChangesAsync();

            return ServiceResult<int>.OK(existTeacher.Id);
        }
    }
}
