using EEWF.Application.CQRS.About.Commands.UpdateAbout;
using EEWF.Application.CQRS.About.Queries.GetAbout;
using EEWF.Application.CQRS.About.Queries.GetAboutById;
using EEWF.Domain.DTOs.About;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {
        private readonly IMediator _mediator;
        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var about = (await _mediator.Send(new GetAboutQuery())).Response;

            return View(about);
        }

        public async Task<IActionResult> Update(int aboutId)
        {
            AboutDto about = (await _mediator.Send(new GetAboutByIdQuery(aboutId))).Response;
            if (about == null) return RedirectToAction("index", "about");
            TempData["AboutId"] = aboutId;
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutDto about)
        {
            int aboutId = (int)TempData["AboutId"];
            var result = await _mediator.Send(new UpdateAboutCommand(aboutId, about.Title, about.Description, about.ImageFile));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }
                AboutDto aboutDto = (await _mediator.Send(new GetAboutByIdQuery(aboutId))).Response;
                TempData["AboutId"] = aboutDto.AboutId;
                about.Image = aboutDto.Image;
                return View(about);
            }
            

            return RedirectToAction("index" , "about");
        }

        
    }
}
