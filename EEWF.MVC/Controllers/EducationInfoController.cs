using EEWF.Application.CQRS.Education.Queries.GetEducation;
using EEWF.Application.CQRS.Education.Queries.GetEducationById;
using EEWF.Application.CQRS.Education.Queries.GetEducationByLevelId;
using EEWF.Domain.DTOs.Education;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EEWF.MVC.Controllers
{
    public class EducationInfoController : Controller
    {
        private readonly IMediator _mediator;

        public EducationInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(int id)
        {
            List<EducationDto> education = (await _mediator.Send(new GetEducationByLevelIdQuery(id))).Response;
            if (education == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(education);
         
        }

        public async Task<IActionResult> About(int id)
        {
            var education = (await _mediator.Send(new GetEducationByIdQuery(id))).Response;
            if (education == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(education);
        }
    }
}
