using Microsoft.AspNetCore.Mvc;

namespace Treino.Web.Areas.Netlify.Controllers
{
    [Area("Netlify")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
