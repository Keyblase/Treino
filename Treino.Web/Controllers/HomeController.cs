using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Treino.Data.API.Model;
using Treino.Web.Models;

namespace Treino.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            //var turmas = new Faker<HomeViewModel>("pt_BR")
            //    .RuleFor(c => c.NomeBotao, f => f.Name.JobArea())
            //    .Generate(10);

            return View(/*turmas*/);
        }

        public IActionResult Entrar()
        {
            return View(new UsuarioModel());
        }

        [Authorize]
        public IActionResult Home()
        {
            return View();
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}