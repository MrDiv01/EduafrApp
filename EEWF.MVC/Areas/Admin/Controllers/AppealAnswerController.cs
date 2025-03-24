using EEWF.Application.CQRS.Appeal.Queries.GetAppealById;
using EEWF.Application.CQRS.AppealAnswer.Commands.SendAnswer;
using EEWF.Application.CQRS.AppealAnswer.Queries.GetAppealAnswerById;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.AppealAnswer;
using EEWF.Domain.Entities;
using EEWF.Infrastructure.Data;
using EEWF.MVC.Areas.Admin.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Policy;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AppealAnswerController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _context;

        public AppealAnswerController(IMediator mediator, IEmailService emailService, ApplicationDbContext context)
        {
            _mediator = mediator;
            _emailService = emailService;
            _context = context;
        }
        public async Task<IActionResult> Index(int appealId)
        {
            AppealViewModel appealVM = new AppealViewModel
            {
                Appeal = (await _mediator.Send(new GetAppealByIdQuery(appealId))).Response,
                
            };

            if(appealVM.Appeal.IsAnswer == true)
            {
                appealVM.AppealAnswer = (await _mediator.Send(new GetAppealAnswerByIdQuery(appealId))).Response;
            }

            TempData["Email"] = appealVM.Appeal.Email;
            TempData["AppealId"] = appealId;
            return View(appealVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppealViewModel model)
        {
            model.AppealAnswer.AppealId = (int)TempData["AppealId"];

            AppealViewModel appealVM = new AppealViewModel
            {
                Appeal = (await _mediator.Send(new GetAppealByIdQuery(model.AppealAnswer.AppealId))).Response,
                AppealAnswer = model.AppealAnswer,
            };
            string appealEmail = (string)TempData["Email"];

            var result = await _mediator.Send(new SendAnswerCommand(model.AppealAnswer.Answer, appealEmail, model.AppealAnswer.AppealId));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View(appealVM);
            }

            string body = string.Empty;

            using (StreamReader reader = new StreamReader("wwwroot/templateHtml/reset-password-email.html"))
            {
                body = reader.ReadToEnd();
            }

            // url değişkenini burada oluşturuyoruz
            string url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/some-endpoint"; // Burada '/some-endpoint' örnek bir yol, ihtiyacınıza göre değiştirebilirsiniz.

            body = body.Replace("{{url}}", url);

            _emailService.Send(appealEmail, "Answer", model.AppealAnswer.Answer);
            return RedirectToAction("index", "appeal");
        }

    }
}
