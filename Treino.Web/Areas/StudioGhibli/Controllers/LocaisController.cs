using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Treino.API.Controllers.V1;
using Treino.ViewModels;

namespace Treino.Web.Controllers
{
    [Area("StudioGhibli")]
    public class LocaisController : Controller
    {
        LocaisApiController _locaisApiController;

        public LocaisController()
        {
            _locaisApiController = new LocaisApiController();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            try
            {
                var locaisObjResult = await _locaisApiController.Listar();
                if (locaisObjResult != null)
                {
                    IEnumerable<LocalModel> listaLocais = (IEnumerable<LocalModel>)locaisObjResult.Value;
                    return View("Lista", listaLocais);
                }
                return View("Lista", null);
            }
            catch (Exception excessao)
            {
                return NotFound(excessao);
            }
        }

        public async Task<IActionResult> ObtemLocal(string id)
        {
            try
            {
                var localObjResult = await _locaisApiController.ListaLocal(id);
                if (localObjResult != null)
                {
                    LocalModel local = (LocalModel)localObjResult.Value;
                    return View("Obtem", local);
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
