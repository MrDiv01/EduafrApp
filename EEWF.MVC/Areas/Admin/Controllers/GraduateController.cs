using EEWF.Application.CQRS.Carousel.Queries.GetCarouselById;
using EEWF.Application.CQRS.Graduate.Commands.CreateGraduate;
using EEWF.Application.CQRS.Graduate.Commands.UpdateGraduate;
using EEWF.Application.CQRS.Graduate.Queries.GetGraduate;
using EEWF.Application.CQRS.Graduate.Queries.GetGraduateById;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Graduate;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class GraduateController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _context;
        public GraduateController(IMediator mediator, IFileService fileService, IWebHostEnvironment env, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
            _env = env;
            _fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetGraduateQuery())).Response;

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GraduateDto graduate)
        {
            var result = await _mediator.Send(new CreateGraduateCommand(graduate.Name, graduate.Degree, graduate.Comment, graduate.ImageFile));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(graduate);
            }


            return RedirectToAction("index", "graduate");
        }

        public async Task<IActionResult> Update(int graduateId)
        {
            var graduate = (await _mediator.Send(new GetGraduateByIdQuery(graduateId))).Response;

            if (graduate == null) return RedirectToAction("index");

            TempData["GraduateId"] = graduateId;

            return View(graduate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(GraduateDto graduate)
        {
            int graduateId = (int)TempData["GraduateId"];

            var result = await _mediator.Send(new UpdateGraduateCommand(graduate.Name, graduate.Degree, graduate.Comment, graduateId, graduate.ImageFile));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                var graduateDto = (await _mediator.Send(new GetGraduateByIdQuery(graduateId))).Response;
                graduate.Image = graduateDto.Image;
                TempData["GraduateId"] = graduateDto.GraduateId;
                return View(graduate);
            }

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int graduateId)
        {
            var existGraduate = (await _mediator.Send(new GetGraduateByIdQuery(graduateId))).Response;

            if (existGraduate == null)
            {
                return RedirectToAction("index", "graduate");
            }

            Graduate graduate = new Graduate
            {
                Id = graduateId,
                Name = existGraduate.Name,
                Degree = existGraduate.Degree,
                Comment = existGraduate.Comment,
                Image = existGraduate.Image,
            };

            _fileService.DeleteImage(_env.WebRootPath, "uploads/graduate", graduate.Image);

            _context.Graduates.Remove(graduate);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "graduate");
        }
    }
}
