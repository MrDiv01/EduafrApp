using EEWF.Application.CQRS.Appeal.Commands;
using EEWF.Application.CQRS.Contact.Queries.GetContact;
using EEWF.Domain.DTOs.Appeal;
using EEWF.MVC.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EEWF.MVC.Controllers
{
	public class ContactController : Controller
	{
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
		{
            //ContactViewModel contactVM = new ContactViewModel
            //{
            //    Contact = (await _mediator.Send(new GetContactQuery())).Response,
            //};
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(AppealDto appeal)
        {

            var result = await _mediator.Send(new SendAppealCommand(appeal.Name, appeal.Surname, appeal.Email, appeal.Subject, appeal.Message));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                ContactViewModel contactVM = new ContactViewModel
                {
					Contact = (await _mediator.Send(new GetContactQuery())).Response,
					Appeal = appeal,
				};

				return View(contactVM);
            }

		
			return RedirectToAction("index", "contact");
        }
	}
}
