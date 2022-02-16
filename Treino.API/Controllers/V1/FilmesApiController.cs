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
    public class FilmesApiController : ControllerBase
    {
        public string baseUrl = "https://ghibliapi.herokuapp.com/films";

        /// <summary>
        /// Requisição para buscar todos as filmes Studio Ghibli
        /// </summary>
        /// <response code="200">Retorna a lista de filmes</response>
        /// <response code="204">Caso não haja filmes</response>
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
                        using (HttpContent content = respostaRequisicao.Content)
                        {
                            var dados = await content.ReadAsStringAsync();
                            if (content != null)
                            {
                                List<FilmeModel> listaFilmes = JsonConvert.DeserializeObject<List<FilmeModel>>(dados);
                                return Ok(listaFilmes);
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
        /// Requisição para buscar a filmes/id Studio Ghibli
        /// </summary>
        /// <param name="id">Parametro id da filme desejado</param>
        /// <param name="url">Parametro de url de pesquisa</param>
        /// <response code="200">Retorna a lista de filme</response>
        /// <response code="204">Caso não haja filme</response>
        [HttpGet("Obtem")]
        public async Task<ObjectResult> ListaFilme(string id = "", string url = "")
        {
            string baseURL;

            if (string.IsNullOrEmpty(url))
            {
                baseURL = $"https://ghibliapi.herokuapp.com/films/{id}/";
            }
            else
            {
                baseURL = url;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            using (HttpContent content = res.Content)
                            {
                                string dados = await content.ReadAsStringAsync();
                                if (dados != null)
                                {
                                    FilmeModel filme = JsonConvert.DeserializeObject<FilmeModel>(dados);
                                    return Ok(filme);
                                }
                                else
                                {
                                    return new NotFoundObjectResult(new { mensagem = "nenhuma resposta da requisição foi encontrada" });
                                }
                            }
                        }
                        else
                        {
                            return new NotFoundObjectResult(new { mensagem = "nenhuma resposta da requisição foi encontrada" });
                        }
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