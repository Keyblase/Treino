using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Treino.ViewModels;

namespace Treino.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PessoasApiController : ControllerBase
    {
        private FilmesApiController _filmesApiController;
        private EspeciesApiController _especiesApiController;

        public string baseUrl = "https://ghibliapi.herokuapp.com/people";

        public PessoasApiController()
        {
            _filmesApiController = new FilmesApiController();
            _especiesApiController = new EspeciesApiController();
        }

        /// <summary>
        /// Requisição para buscar todos as pessoas Studio Ghibli
        /// </summary>
        /// <response code="200">Retorna a lista de pessoas</response>
        /// <response code="204">Caso não haja pessoas</response>
        [HttpGet("Listar")]
        //[Route("autenticado")]
        //[Authorize]
        public async Task<ObjectResult> Listar()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage respostaRequisicao = await client.GetAsync(baseUrl))
                    {
                        if (respostaRequisicao.IsSuccessStatusCode)
                        {
                            using (HttpContent conteudo = respostaRequisicao.Content)
                            {
                                if (conteudo != null)
                                {
                                    List<PessoaModel> listaPessoas = JsonConvert.DeserializeObject<List<PessoaModel>>(await conteudo.ReadAsStringAsync());

                                    //Gargalo, precisa paginação
                                    //foreach (var pessoa in listaPessoas)
                                    //{
                                    //    foreach (var filmeUrl in pessoa.films)
                                    //    {
                                    //        var objFilme = await _filmesApiController.ListaFilme("", filmeUrl);
                                    //        FilmeModel filmeModel = (FilmeModel)objFilme.Value;
                                    //        pessoa.filmesModel.Add(filmeModel);
                                    //    }
                                    //}
                                    return Ok(listaPessoas);
                                }
                            }
                        }
                    }
                    return new NotFoundObjectResult(new { mensagem = "nenhuma resposta da requisição foi encontrada" });
                }
            }
            catch (Exception excessao)
            {
                var badRequest = new BadRequestObjectResult(excessao.Message);
                return badRequest;
            }
        }

        /// <summary>
        /// Requisição para buscar a pessoas/id Studio Ghibli
        /// </summary>
        /// <param name="id">Parametro id da pessoa desejado</param>
        /// <param name="url">Parametro de url de pesquisa</param>
        /// <response code="200">Retorna a lista de pessoa</response>
        /// <response code="204">Caso não haja pessoa</response>
        [HttpGet("Obtem")]
        public async Task<ObjectResult> ListaPessoa(string id = "", string url = "")
        {
            baseUrl = string.IsNullOrEmpty(url) ? baseUrl += $"/{id}/" : baseUrl = url;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage respostaRequisicao = await client.GetAsync(baseUrl))
                    {
                        if (respostaRequisicao.IsSuccessStatusCode)
                        {
                            using (HttpContent conteudo = respostaRequisicao.Content)
                            {
                                if (conteudo != null)
                                {
                                    PessoaModel pessoa = JsonConvert.DeserializeObject<PessoaModel>(await conteudo.ReadAsStringAsync());
                                    foreach (var filmeUrl in pessoa.films)
                                    {
                                        var objFilme = await _filmesApiController.ListaFilme("", filmeUrl);
                                        FilmeModel filmeModel = (FilmeModel)objFilme.Value;
                                        pessoa.filmesModel.Add(filmeModel);
                                    }

                                    var objEspecie = await _especiesApiController.ListaEspecie("", pessoa.species);
                                    EspecieModel especieModel = (EspecieModel)objEspecie.Value;
                                    pessoa.especieModel = especieModel;

                                    return Ok(pessoa);
                                }
                                return new NotFoundObjectResult(new { mensagem = "nenhuma resposta da requisição foi encontrada" });
                            }
                        }
                        return new NotFoundObjectResult(new { mensagem = "nenhuma resposta da requisição foi encontrada" });
                    }
                }
            }
            catch (Exception excessao)
            {
                var badRequest = new BadRequestObjectResult(excessao.Message);
                return badRequest;
            }
        }
    }
}