using EEWF.Application.CQRS.Category.Queries.GetCategoryById;
using EEWF.Application.CQRS.Teacher.Commands.CreateTeacher;
using EEWF.Application.CQRS.Teacher.Commands.UpdateTeacher;
using EEWF.Application.CQRS.Teacher.Queries.GetTeacher;
using EEWF.Application.CQRS.Teacher.Queries.GetTeacherById;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Teacher;
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
    public class TeacherController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;

        public TeacherController(IMediator mediator, ApplicationDbContext context, IFileService fileService, IWebHostEnvironment env)
        {
            _context = context;
            _mediator = mediator;
            _env = env;
            _fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetTeacherQuery())).Response;
            
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.TeacherCategories = await _context.TeacherCategories.Select(x => new TeacherCategoryDto { 
                TeacherCategoryId = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherDto teacher)
        {
            ViewBag.TeacherCategories = await _context.TeacherCategories.Select(x => new TeacherCategoryDto { 
                TeacherCategoryId = x.Id,
                Name = x.Name,
            }).ToListAsync();
            var result = await _mediator.Send(new CreateTeacherCommand(teacher.Name, teacher.Surname, teacher.Description, teacher.Category.TeacherCategoryId, teacher.ImageFile));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(teacher);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int teacherId)
        {
            ViewBag.TeacherCategories = await _context.TeacherCategories.Select(x => new TeacherCategoryDto
            {
                TeacherCategoryId = x.Id,
                Name = x.Name,
            }).ToListAsync();

            var teacher = (await _mediator.Send(new GetTeacherByIdQuery(teacherId))).Response;

            if (teacher == null) return RedirectToAction("index");
            TempData["TeacherId"] = teacherId;
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TeacherDto teacher)
        {
            ViewBag.TeacherCategories = await _context.TeacherCategories.Select(x => new TeacherCategoryDto
            {
                TeacherCategoryId = x.Id,
                Name = x.Name,
            }).ToListAsync();
            int teacherId = (int)TempData["TeacherId"];

            var result = await _mediator.Send(new UpdateTeacherCommand(teacher.Name, teacher.Surname, teacher.Description, teacherId, teacher.ImageFile));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                var teacherDto = (await _mediator.Send(new GetTeacherByIdQuery(teacherId))).Response;

                TempData["TeacherId"] = teacherDto.TeacherId;

                return View(teacher);
            }

            TempData["TeacherId"] = 0;
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int teacherId)
        {
            var existTeacher = (await _mediator.Send(new GetTeacherByIdQuery(teacherId))).Response;

            if (existTeacher == null)
            {
                return RedirectToAction("index", "teacher");
            }

            Teacher teacher = new Teacher
            {
                Id = teacherId,
                Name = existTeacher.Name,
                Surname = existTeacher.Surname,
                Description = existTeacher.Description,
                Image = existTeacher.Image,
            };

            _fileService.DeleteImage(_env.WebRootPath, "uploads/teacher", teacher.Image);

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction("index", "teacher");
        }
    }
}
