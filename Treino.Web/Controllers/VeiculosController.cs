using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Treino.API.Controllers.V1;
using Treino.ViewModels;

namespace Treino.Web.Controllers
{
    public class VeiculosController : Controller
    {
        VeiculosApiController _veiculosApiController;
        public VeiculosController()
        {
            _veiculosApiController = new VeiculosApiController();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            try
            {
                var veiculoObjResult = await _veiculosApiController.Listar();
                if (veiculoObjResult != null)
                {
                    IEnumerable<VeiculoModel> listaVeiculos = (IEnumerable<VeiculoModel>)veiculoObjResult.Value;
                    return View("Lista", listaVeiculos);
                }
                return View("Lista", null);
            }
            catch (Exception excessao)
            {
                return NotFound(excessao);
            }
        }

        public async Task<IActionResult> ObtemVeiculo(string id)
        {
            try
            {
                var veiculoObjResult = await _veiculosApiController.ListaVeiculo(id);
                if (veiculoObjResult != null)
                {
                    VeiculoModel veiculo = (VeiculoModel)veiculoObjResult.Value;
                    return View("Obtem", veiculo);
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
