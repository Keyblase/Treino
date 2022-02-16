using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Treino.API.Controllers.V1;
using Treino.Core.Entidades;
using Treino.Core.Interfaces;
using Treino.ViewModels;

namespace Treino.Web.Controllers
{
    public class FilmesController : Controller
    {
        FilmesApiController _filmesApiController;
        IFilmesService _filmesService;
        public FilmesController(IFilmesService filmesService)
        {
            _filmesService = filmesService;
            _filmesApiController = new FilmesApiController();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            try
            {
                var filmesObjResult = await _filmesApiController.Listar();
                if (filmesObjResult != null)
                {
                    IEnumerable<FilmeModel> listaFiles = (IEnumerable<FilmeModel>)filmesObjResult.Value;
                    return View("Lista", listaFiles);
                }
                return View("Lista", null);
            }
            catch (Exception excessao)
            {
                return NotFound(excessao);
            }
        }

        public async Task<IActionResult> ObtemFilme(string id)
        {
            try
            {
                var filmeObjResult = await _filmesApiController.ListaFilme(id);
                if (filmeObjResult != null)
                {
                    FilmeModel filme = (FilmeModel)filmeObjResult.Value;
                    FilmeEntity filmeEntity = new FilmeEntity()
                    {
                        Id = Guid.Parse(filme.id),
                        Descricao = filme.description,
                        Diretor = filme.director,
                        Data_Lancamento = filme.release_date,
                        Localizacoes = new List<LocalEntity>(){ new LocalEntity() { Nome = "testeLocal"} }/*filme.locations*/,
                        Pessoas = new List<PessoaEntity>() { new PessoaEntity() { Nome = "testePessoa" } }/*filme.people*/,
                        Produtor = filme.producer,
                        Score = filme.rt_score,
                        Especies = new List<EspecieEntity>() { new EspecieEntity() { Nome = "testeEspecie" } }/*filme.species*/,
                        Titulo = filme.title,
                        Veiculos = new List<VeiculoEntity>() { new VeiculoEntity() { Nome = "testeVeiculo" } }/*filme.vehicles*/,
                        Url = filme.url,
                        Inativo = false,
                        Inclusao = DateTime.Now,
                    };
                    //var teste = _filmesService.Add(filmeEntity);
                    return View("Obtem", filme);
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