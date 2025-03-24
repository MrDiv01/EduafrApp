using EEWF.Application.CQRS.About.Queries.GetAbout;
using EEWF.Domain.DTOs.About;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EEWF.MVC.Controllers
{
	public class AboutController : Controller
	{
		private readonly IMediator _mediator;

		public AboutController(IMediator mediator)
		{
			_mediator = mediator;
		}
		public async Task<IActionResult> Index()
		{
			AboutDto about = (await _mediator.Send(new GetAboutQuery())).Response;
			return View(about);
		}
	}
}
