using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Treino.API.Controllers.V1;
using Treino.ViewModels;

namespace Treino.Web.Controllers
{
    public class EspeciesController : Controller
    {
        EspeciesApiController _especiesApiController;
        public EspeciesController()
        {
            _especiesApiController = new EspeciesApiController();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            try
            {
                var especiesObjResult = await _especiesApiController.Listar();
                if (especiesObjResult != null)
                {
                    IEnumerable<EspecieModel> listaEspecies = (IEnumerable<EspecieModel>)especiesObjResult.Value;
                    return View("Lista", listaEspecies);
                }
                return View("Lista", null);
            }
            catch (Exception excessao)
            {
                return NotFound(excessao);
            }
        }

        public async Task<IActionResult> ObtemEspecie(string id)
        {
            try
            {
                var especiesObjResult = await _especiesApiController.ListaEspecie(id);
                if (especiesObjResult != null)
                {
                    EspecieModel especie = (EspecieModel)especiesObjResult.Value;
                    return View("Obtem", especie);
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
