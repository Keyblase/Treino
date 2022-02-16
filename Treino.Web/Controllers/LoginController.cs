using Microsoft.AspNetCore.Mvc;
using Treino.API.Controllers.V1;
using Treino.Data.API.Model;

namespace Treino.Web.Controllers
{
    public class LoginController : Controller
    {
        LoginApiController _loginApiController;

        public LoginController()
        {
            _loginApiController = new LoginApiController();
        }
        public IActionResult Authenticate(string nome, string senha)
        {
            UsuarioModel usuario = new UsuarioModel() { Nome = nome, Senha = senha };

            var UsuarioExistente = _loginApiController.Authenticate(usuario);

            if (UsuarioExistente.Result != null)
            {
                return View("~/Views/Home/Home.cshtml");
            }

            return View("~/Views/Home/Entrar.cshtml");
        }
    }
}
