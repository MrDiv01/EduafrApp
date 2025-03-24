using EEWF.Application.CQRS.Carousel.Commands.CreateCarousel;
using EEWF.Application.CQRS.Carousel.Commands.UpdateCarousel;
using EEWF.Application.CQRS.Carousel.Queries.GetCarousel;
using EEWF.Application.CQRS.Carousel.Queries.GetCarouselById;
using EEWF.Application.CQRS.Category.Queries.GetCategoryById;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Carousel;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CarouselController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public CarouselController(ApplicationDbContext context, IMediator mediator, IFileService fileService, IWebHostEnvironment env)
        {
            _context = context;
            _mediator = mediator;
            _fileService = fileService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetCarouselQeuery())).Response;


            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarouselDto carousel)
        {
            var result = await _mediator.Send(new CreateCarouselCommand(carousel.Title, carousel.Description, carousel.Url, carousel.ButtonText, carousel.ImageFile));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(carousel);
            }

            
            return RedirectToAction("index" , "carousel");
        }

        public async Task<IActionResult> Update(int carouselId)
        {
            CarouselDto carousel = (await _mediator.Send(new GetCarouselByIdQuery(carouselId))).Response;

            if (carousel == null) return RedirectToAction("index", "carousel");

            TempData["CarouselId"] = carouselId;

            return View(carousel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarouselDto carousel)
        {
            int carouselId = (int)TempData["CarouselId"];

            var result = await _mediator.Send(new UpdateCarouselCommand(carouselId, carousel.Title, carousel.Description, carousel.Url, carousel.ButtonText, carousel.ImageFile));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }
                CarouselDto carouselDto = (await _mediator.Send(new GetCarouselByIdQuery(carouselId))).Response;
                carousel.Image = carouselDto.Image;
                TempData["CarouselId"] = carouselDto.CarouselId;

                return View(carousel);
            }
                
            TempData["CarouselId"] = 0;

            return RedirectToAction("index", "carousel");
        }

        public async Task<IActionResult> Delete(int carouselId)
        {
            var existCarousel = (await _mediator.Send(new GetCarouselByIdQuery(carouselId))).Response;

            if (existCarousel == null)
            {
                return RedirectToAction("index", "carousel");
            }

            Carousel carousel = new Carousel
            {
                Id = carouselId,
                Image = existCarousel.Image,
                Description = existCarousel.Description,
                ButtonText = existCarousel.ButtonText,
                Url = existCarousel.Url,
                Title = existCarousel.Title,
            };

            _fileService.DeleteImage(_env.WebRootPath, "uploads/carousel", carousel.Image);

            _context.Carousels.Remove(carousel);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "carousel");
        }
    }
}
