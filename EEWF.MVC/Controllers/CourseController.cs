using EEWF.Application.CQRS.Carousel.Queries.GetCarousel;
using EEWF.Application.CQRS.Education.Queries.GetEducation;
using EEWF.Domain.DTOs.Carousel;
using EEWF.Domain.DTOs.Education;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EEWF.MVC.Controllers
{
	public class CourseController : Controller
	{
		private readonly IMediator _mediator;

		public CourseController(IMediator mediator)
        {
			_mediator = mediator;
		}
        public async Task<IActionResult> Index()
		{
			List<EducationDto> educations = (await _mediator.Send(new GetEducationQuery())).Response;
				return View(educations);
		}
	}
}
