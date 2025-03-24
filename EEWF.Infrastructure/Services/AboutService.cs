using EEWF.Application.Core;
using EEWF.Application.CQRS.About.Commands.UpdateAbout;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.About;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Services
{
    public class AboutService : IAboutService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileService _fileService;
        public AboutService(ApplicationDbContext context, IWebHostEnvironment env, IFileService fileService)
        {
            _context = context;
            _env = env;
            _fileService = fileService;
        }
        public async Task<ServiceResult<AboutDto>> GetAbout()
        {
            var about = await _context.Abouts.Select(x => new AboutDto
            {
                AboutId = x.Id,
                Title = x.Title,
                Description = x.Description,
                Image = x.Image,
            }).FirstOrDefaultAsync();

            return ServiceResult<AboutDto>.OK(about);
        }

        public async Task<ServiceResult<AboutDto>> GetAboutById(int aboutId)
        {
            var about = await _context.Abouts.Where(x => x.Id == aboutId).Select(x => new AboutDto
            {
                AboutId = x.Id,
                Title = x.Title,
                Description = x.Description,
                Image = x.Image,
            }).FirstOrDefaultAsync();

            return ServiceResult<AboutDto>.OK(about);
        }

        public async Task<ServiceResult<int>> UpdateAbout(UpdateAboutCommand command)
        {
            About about = await _context.Abouts.Where(x => x.Id == command.AboutId).FirstOrDefaultAsync();

            about.Title = command.Title;
            about.Description = command.Description;

            if (command.ImageFile != null)
            {
                _fileService.DeleteImage(_env.WebRootPath, "uploads/about", about.Image);
                about.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/about", command.ImageFile);
            }
            


            await _context.SaveChangesAsync();

            return ServiceResult<int>.OK(about.Id);
        }
    }
}
