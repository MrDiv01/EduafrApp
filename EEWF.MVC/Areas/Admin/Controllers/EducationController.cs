using EEWF.Application.CQRS.Carousel.Queries.GetCarouselById;
using EEWF.Application.CQRS.Education.Commands.CreateEducation;
using EEWF.Application.CQRS.Education.Commands.UpdateEducation;
using EEWF.Application.CQRS.Education.Queries.GetEducation;
using EEWF.Application.CQRS.Education.Queries.GetEducationById;
using EEWF.Application.CQRS.Level.Queries.GetLevel;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Education;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class EducationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public EducationController(IMediator mediator, IFileService fileService, ApplicationDbContext context, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _context = context;
            _fileService = fileService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetEducationQuery())).Response;
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
           ViewBag.Data  = (await _mediator.Send(new GetLevelQuery())).Response;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EducationDto education)
        {
            var result = await _mediator.Send(new CreateEducationCommand(education.Name, education.Description, education.ImageFile,education.LevelId));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(education);
            }
            return RedirectToAction("index", "education");
        }

        public async Task<IActionResult> Update(int educationId)
        {
            var result = (await _mediator.Send(new GetEducationByIdQuery(educationId))).Response;

            if (result == null) return RedirectToAction("index", "education");

            TempData["EducationId"] = educationId;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EducationDto education)
        {
            int educationId = (int)TempData["EducationId"];

            var result = await _mediator.Send(new UpdateEducationCommand(education.Name, education.Description, education.ImageFile, educationId));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                var educationDto = (await _mediator.Send(new GetEducationByIdQuery(educationId))).Response;
                TempData["EducationId"] = educationDto.EducationId;

                return View(education);
            }

            TempData["EducationId"] = 0;
            return RedirectToAction("index", "education");
        }

        public async Task<IActionResult> Delete(int educationId)
        {
            var existEducation = (await _mediator.Send(new GetEducationByIdQuery(educationId))).Response;

            if (existEducation == null)
            {
                return RedirectToAction("index", "education");
            }

            Education education = new Education
            {
                Id = educationId,
                Image = existEducation.Image,
                Description = existEducation.Description,
                Name = existEducation.Name,
            };

            _fileService.DeleteImage(_env.WebRootPath, "uploads/education", education.Image);

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "education");
        }
    }
}
