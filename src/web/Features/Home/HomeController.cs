using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Features.Home
{
    public class HomeController : Controller 
    {
        private IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new Index.Command()));
        }

        [HttpPost]
        public async Task<IActionResult> Generate()
        {
            return View("Index", await _mediator.Send(new Index.Command()));
        }

        [HttpPost]
        public async Task<IActionResult> Exists(Exists.Query query)
        {
            return View(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Reset()
        {
            await _mediator.Send(new Reset.Command());

            return RedirectToAction("Index");
        }
    }
}
