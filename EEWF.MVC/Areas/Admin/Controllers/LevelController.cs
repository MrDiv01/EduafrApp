using EEWF.Application.CQRS.Category.Queries.GetCategoryById;
using EEWF.Application.CQRS.Level.Commands.CreateLevel;
using EEWF.Application.CQRS.Level.Commands.UpdateLevel;
using EEWF.Application.CQRS.Level.Queries.GetLevel;
using EEWF.Application.CQRS.Level.Queries.GetLevelById;
using EEWF.Domain.DTOs.Level;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LevelController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        public LevelController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context; 
        }
        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetLevelQuery())).Response;

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LevelDto level)
        {
            var result = await _mediator.Send(new CreateLevelCommand(level.Name, level.URL));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(level);
            }
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Update(int levelId)
        {
            var result = (await _mediator.Send(new GetLevelByIdQuery(levelId))).Response;

            if (result == null) return RedirectToAction("index");

            TempData["LevelId"] = levelId;

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LevelDto level)
        {
            int levelId = (int)TempData["LevelId"];
            var result = await _mediator.Send(new UpdateLevelCommand(levelId, level.Name, level.URL));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                var resultDto = (await _mediator.Send(new GetLevelByIdQuery(levelId))).Response;
                TempData["LevelId"] = resultDto.LevelId;

                return View(level);
            }

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int levelId)
        {
            var existLevel = (await _mediator.Send(new GetLevelByIdQuery(levelId))).Response;

            if (existLevel == null)
            {
                return RedirectToAction("index", "level");
            }

            Level level = new Level
            {
                Id = levelId,
                Name = existLevel.Name,
      
            };

            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "level");
        }
    }
}
