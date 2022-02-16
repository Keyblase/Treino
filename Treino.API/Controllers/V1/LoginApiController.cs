using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Treino.Data.API.Model;
using Treino.Data.API.Repositories;
using Treino.Data.API.Services;

namespace Treino.API.Controllers.V1
{
    //[Route("api/v1/[controller]")]
    //[ApiController]
    public class LoginApiController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginModel>> Authenticate([FromBody] UsuarioModel modelo)
        {
            var usuario = UsuarioRepository.Get(modelo.Nome, modelo.Senha);

            if (usuario == null)
            {
                //var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return NotFound(new { message = "Usuario ou senha invalido" });
            }

            var token = TokensService.GerarToken(usuario);
            usuario.Senha = "";

            return new LoginModel
            {
                Usuario = usuario,
                Token = token
            };
        }

        [HttpGet]
        [Route("anonimos")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => string.Format("Autenticado - {0}", User.Identity.Name); //pega do claims

        [HttpGet]
        [Route("colaborador")]
        [Authorize(Roles = "colaborador,administrador")]
        public string Colaborador() => "colaborador";

        [HttpGet]
        [Route("administrador")]
        [Authorize(Roles = "administrador")]
        public string Administrador() => "adm";
    }
}