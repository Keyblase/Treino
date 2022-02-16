using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Treino.API.Controllers.V1;
using Treino.ViewModels;

namespace Treino.Web.Controllers
{
    public class PessoasController : Controller
    {
        PessoasApiController _pessoasApiController;

        public PessoasController()
        {
            _pessoasApiController = new PessoasApiController();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            try
            {
                var pessoaObjResult = await _pessoasApiController.Listar();
                if (pessoaObjResult != null)
                {
                    IEnumerable<PessoaModel> listaPessoas = (IEnumerable<PessoaModel>)pessoaObjResult.Value;
                    return View("Lista", listaPessoas);
                }
                return View("Lista", null);
            }
            catch (Exception excessao)
            {
                return NotFound(excessao);
            }
        }

        public async Task<IActionResult> ObtemPessoa(string id)
        {
            try
            {
                var pessoaObjResult = await _pessoasApiController.ListaPessoa(id);
                if (pessoaObjResult != null)
                {
                    PessoaModel pessoa = (PessoaModel)pessoaObjResult.Value;
                    return View("Obtem", pessoa);
                }
                return View("Obtem", null);
            }
            catch (Exception excessao)
            {
                return NotFound(excessao);
            }
        }
    }
}
