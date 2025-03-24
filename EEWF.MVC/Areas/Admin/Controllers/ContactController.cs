using EEWF.Application.CQRS.Contact.Command.UpdateContact;
using EEWF.Application.CQRS.Contact.Queries.GetContact;
using EEWF.Application.CQRS.Contact.Queries.GetContactById;
using EEWF.Domain.DTOs.Contact;
using EEWF.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EEWF.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var contact = (await _mediator.Send(new GetContactQuery())).Response;
            return View(contact);
        }

        public async Task<IActionResult> Update(int contactId)
        {
            ContactDto contact = (await _mediator.Send(new GetContactByIdQuery(contactId))).Response;

            if(contact == null)
            {
                return RedirectToAction("index", "context");
            }
            TempData["ContactId"] = contact.ContactId;

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactDto contact)
        {
            int contactId = (int)TempData["ContactId"];

            var result = await _mediator.Send(new UpdateContactCommand(contactId, contact.Location, contact.Phone, contact.Mail));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }
                ContactDto contactDto = (await _mediator.Send(new GetContactByIdQuery(contactId))).Response;
                TempData["ContactId"] = contactDto.ContactId;

                return View(contact);
            }
            return RedirectToAction("index", "contact");
        }
    }
}
