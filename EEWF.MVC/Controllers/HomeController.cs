using EEWF.Application.CQRS.Carousel.Queries.GetCarousel;
using EEWF.Application.CQRS.Category.Queries.GetCategory;
using EEWF.Application.CQRS.Education.Queries.GetEducation;
using EEWF.Application.CQRS.Graduate.Queries.GetGraduate;
using EEWF.Application.CQRS.Level.Queries.GetLevel;
using EEWF.MVC.Models;
using EEWF.MVC.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EEWF.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                carousels = (await _mediator.Send(new GetCarouselQeuery())).Response,
                categories = (await _mediator.Send(new GetCategoryQuery())).Response,
                graduates = (await _mediator.Send(new GetGraduateQuery())).Response,
                level = (await _mediator.Send(new GetLevelQuery())).Response
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}