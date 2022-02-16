using Microsoft.AspNetCore.Mvc;

namespace Treino.Web.Areas.StudioGhibli.Controllers
{
    [Area("StudioGhibli")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
