using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Treino.API.Controllers.V1;
using Treino.ViewModels;
using Treino.ViewModels.ViewModels;

namespace Treino.Web.Controllers
{
    [Area("StudioGhibli")]
    public class VeiculosController : Controller
    {
        VeiculosApiController _veiculosApiController;
        FilmesApiController _filmeApiController;
        PessoasApiController _pessoaApiController;

        public VeiculosController()
        {
            _veiculosApiController = new VeiculosApiController();
            _filmeApiController = new FilmesApiController();
            _pessoaApiController = new PessoasApiController();

        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            try
            {
                VeiculoViewModel veiculoViewModel = new VeiculoViewModel();

                var veiculos = await _veiculosApiController.Listar();
                veiculoViewModel.ListaVeiculos = (IEnumerable<VeiculoModel>)veiculos.Value;
                List<FilmeModel> filmeModel = new List<FilmeModel>();

                foreach (var veiculo in veiculoViewModel.ListaVeiculos)
                {
                    foreach (var filmes in veiculo.Films)
                    {
                        var filmesObj = await _filmeApiController.ListaFilme("", filmes);
                        filmeModel.Add((FilmeModel)filmesObj.Value);
                    }
                    veiculoViewModel.ListaFilme = filmeModel;
                    var pessoaObj = await _pessoaApiController.ListaPessoa("", veiculo.Pilot);
                    veiculoViewModel.Pessoa = (PessoaModel)pessoaObj.Value;             
                }

                return View("Lista", veiculoViewModel);
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
