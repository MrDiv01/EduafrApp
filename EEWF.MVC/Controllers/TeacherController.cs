using EEWF.Application.CQRS.Teacher.Queries.GetTeacher;
using EEWF.Domain.DTOs.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EEWF.MVC.Controllers
{
	public class TeacherController : Controller
	{
		private readonly IMediator _mediator;

		public TeacherController(IMediator mediator)
        {
			_mediator = mediator;
		}
        public async Task<IActionResult> Index()
		{
			List<TeacherDto> teacher = (await _mediator.Send(new GetTeacherQuery())).Response;
			return View(teacher);
		}
	}
}
