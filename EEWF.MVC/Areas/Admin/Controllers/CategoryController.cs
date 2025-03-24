using EEWF.Application.CQRS.Category.Commands.CreateCategory;
using EEWF.Application.CQRS.Category.Commands.UpdateCategory;
using EEWF.Application.CQRS.Category.Queries.GetCategory;
using EEWF.Application.CQRS.Category.Queries.GetCategoryById;
using EEWF.Domain.DTOs.Category;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public CategoryController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = (await _mediator.Send(new GetCategoryQuery())).Response;

            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto category)
        {
            var result = await _mediator.Send(new CreateCategoryCommand(category.Name, category.Icon, category.Description));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(category);
            }

            return RedirectToAction("index" , "category");
        }

        public async Task<IActionResult> Update(int categoryId)
        {
            var category = (await _mediator.Send(new GetCategoryByIdQuery(categoryId))).Response;

            if(category == null)
            {
                return RedirectToAction("index", "category");
            }

            TempData["CategoryId"] = categoryId;

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto category)
        {
            int categoryId = (int)TempData["CategoryId"];
            var result = await _mediator.Send(new UpdateCategoryCommand(categoryId, category.Name, category.Icon, category.Description));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }
                var categoryDto = (await _mediator.Send(new GetCategoryByIdQuery(categoryId))).Response;
                TempData["CategoryId"] = categoryDto.CategoryId;

                return View(category);
            }

            return RedirectToAction("index", "category");
        }

        public async Task<IActionResult> Delete(int categoryId)
        {
            var existCategory = (await _mediator.Send(new GetCategoryByIdQuery(categoryId))).Response;

            if (existCategory == null)
            {
                return RedirectToAction("index", "category");
            }

            Category category = new Category
            {
                Id = categoryId,
                Name = existCategory.Name,
                Icon = existCategory.Icon,
                Description = existCategory.Description,
            };

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "category");
        }
    }
}
