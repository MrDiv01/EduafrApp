using EEWF.Application.CQRS.TeacherCategory.Commands.CreateTeacherCategory;
using EEWF.Application.CQRS.TeacherCategory.Commands.UpdateTeacherCategory;
using EEWF.Application.CQRS.TeacherCategory.Queries.GetTeacherCategory;
using EEWF.Application.CQRS.TeacherCategory.Queries.GetTeacherCategoryById;
using EEWF.Domain.DTOs.TeacherCategory;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class TeacherCategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        public TeacherCategoryController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetTeacherCategoryQuery())).Response;

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCategoryDto category)
        {
            var result = await _mediator.Send(new CreateTeacherCategoryCommand(category.Name));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(category);
            }

            return RedirectToAction("index", "teachercategory");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = (await _mediator.Send(new GetTeacherCategoryByIdCommand(id))).Response;

            if(result == null)
            {
                return RedirectToAction("index", "teachercategory");
            }

            TempData["CategoryId"] = id;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TeacherCategoryDto category)
        {
            int categoryId = (int)TempData["CategoryId"];
            var result = await _mediator.Send(new UpdateTeacherCategoryCommand(category.Name, categoryId));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                var categoryDto = (await _mediator.Send(new GetTeacherCategoryByIdCommand(categoryId))).Response;
                TempData["CategoryId"] = categoryDto.TeacherCategoryId;

                return View(category);
            }

            TempData["CategoryId"] = 0;
            return RedirectToAction("index", "teachercategory");
        }

        public async Task<IActionResult> Delete(int categoryId)
        {
            var existCategory = (await _mediator.Send(new GetTeacherCategoryByIdCommand(categoryId))).Response;

            TeacherCategory category = new TeacherCategory
            {
                Id = categoryId,
                Name = existCategory.Name,
            };

            _context.TeacherCategories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "teachercategory");
        }
    }
}
