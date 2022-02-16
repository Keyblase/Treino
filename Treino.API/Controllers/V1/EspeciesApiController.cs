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
    public class EspeciesApiController : ControllerBase
    {
        public string baseUrl = "https://ghibliapi.herokuapp.com/species";

        /// <summary>
        /// Requisição para buscar todos as especies Studio Ghibli
        /// </summary>
        /// <response code="200">Retorna a lista de especies</response>
        /// <response code="204">Caso não haja especies</response>
        [HttpGet("Listar")]
        //[Route("autenticado")]
        //[Authorize]

        public async Task<ObjectResult> Listar()
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage respostaRequisicao = await cliente.GetAsync(baseUrl))
                    {
                        if (respostaRequisicao.IsSuccessStatusCode)
                        {
                            using (HttpContent conteudo = respostaRequisicao.Content)
                            {
                                if (conteudo != null)
                                {
                                    return Ok(JsonConvert.DeserializeObject<List<EspecieModel>>(await conteudo.ReadAsStringAsync()));
                                }
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

        /// <summary>
        /// Requisição para buscar a especies/id Studio Ghibli
        /// </summary>
        /// <param name="id">Parametro id da especie desejada</param>
        /// <param name="url">Parametro de url de pesquisa</param>
        /// <response code="200">Retorna a lista de especie</response>
        /// <response code="204">Caso não haja especie</response>
        [HttpGet("Obtem")]
        public async Task<ObjectResult> ListaEspecie(string id = "", string url = "")
        {
            baseUrl = string.IsNullOrEmpty(url) ? baseUrl += $"/{id}/" : baseUrl = url;

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage respostaRequisicao = await cliente.GetAsync(baseUrl))
                    {
                        if (respostaRequisicao.IsSuccessStatusCode)
                        {
                            using (HttpContent conteudo = respostaRequisicao.Content)
                            {
                                if (conteudo != null)
                                {
                                    return Ok(JsonConvert.DeserializeObject<EspecieModel>(await conteudo.ReadAsStringAsync()));
                                }
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