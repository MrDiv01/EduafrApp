using EEWF.Application.CQRS.Appeal.Queries.GetAppeal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EEWF.MVC.Areas.Admin.Controllers
{
	[Area("admin")]
	public class AppealController : Controller
	{
		private readonly IMediator _mediator;
        public AppealController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
		{
			var result = (await _mediator.Send(new GetAppealQuery())).Response;
			return View(result);
		}
	}
}
