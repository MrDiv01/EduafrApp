using EEWF.Application.Core;
using EEWF.Application.CQRS.Carousel.Commands.CreateCarousel;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Carousel;
using EEWF.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using EEWF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEWF.Application.CQRS.Carousel.Commands.UpdateCarousel;
using EEWF.Application.CQRS.Category.Queries.GetCategoryById;
using Microsoft.AspNetCore.Mvc;

namespace EEWF.Infrastructure.Services
{
    public class CarouselService : ICarouselService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public CarouselService(ApplicationDbContext context , IFileService fileService, IWebHostEnvironment env)
        {
            _context = context;
            _fileService = fileService;
            _env = env;
        }
        public async Task<ServiceResult<int>> CreateCarousel(CreateCarouselCommand command)
        {
            Carousel carousel = new Carousel
            {
                ButtonText = command.ButtonText,
                Description = command.Description,
                Title = command.Title,
                Url = command.Url,
                Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/carousel", command.ImageFile),
            };

            await _context.Carousels.AddAsync(carousel);
            await _context.SaveChangesAsync();
            return ServiceResult<int>.OK(carousel.Id);
        }

        
        public async Task<ServiceResult<List<CarouselDto>>> GetCarousel()
        {
            List<CarouselDto> carusel = await _context.Carousels.Select(x => new CarouselDto
            {
                CarouselId = x.Id,
                Description = x.Description,
                Title = x.Title,
                ButtonText =x.ButtonText,
                Url = x.Url,
                Image = x.Image
            }).ToListAsync();
            return  ServiceResult<List<CarouselDto>>.OK(carusel);
        }

        public async Task<ServiceResult<CarouselDto>> GetCarouselById(int carouselId)
        {
            var result = await _context.Carousels.Where(x => x.Id == carouselId).Select(x => new CarouselDto
            {
                CarouselId = x.Id,
                Title = x.Title,
                Description = x.Description,
                Url = x.Url,
                ButtonText = x.ButtonText,
                Image = x.Image,
            }).FirstOrDefaultAsync();

            return ServiceResult<CarouselDto>.OK(result);
        }

        public async Task<ServiceResult<int>> UpdateCarousel(UpdateCarouselCommand command)
        {
            var existCarousel = await _context.Carousels.Where(x => x.Id == command.CarouselId).FirstOrDefaultAsync();

            if(existCarousel != null)
            {
                existCarousel.Title = command.Title;
                existCarousel.Description = command.Description;
                existCarousel.Url = command.Url;
                existCarousel.ButtonText = command.ButtonText;

                if(command.ImageFile != null)
                {
                    _fileService.DeleteImage(_env.WebRootPath, "uploads/carousel", existCarousel.Image);
                    existCarousel.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/carousel", command.ImageFile);
                }
                
            }

            await _context.SaveChangesAsync();
            return ServiceResult<int>.OK(existCarousel.Id);
        }

        
    }
}
