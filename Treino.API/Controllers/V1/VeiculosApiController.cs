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
    public class VeiculosApiController : ControllerBase
    {
        /// <summary>
        /// Requisição para buscar todos as veiculos Studio Ghibli
        /// </summary>
        /// <response code="200">Retorna a lista de veiculos</response>
        /// <response code="204">Caso não haja veiculos</response>
        [HttpGet("Listar")]
        //[Route("autenticado")]
        //[Authorize]
        public async Task<ObjectResult> Listar()
        {
            string baseUrl = "https://ghibliapi.herokuapp.com/vehicles";

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
                                List<VeiculoModel> listaVeiculos = JsonConvert.DeserializeObject<List<VeiculoModel>>(dados);
                                return Ok(listaVeiculos);
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

        [HttpGet]
        public async Task<ObjectResult> ListaVeiculo(string id)
        {
            string baseURL = $"https://ghibliapi.herokuapp.com/vehicles/{id}/";

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
                                    VeiculoModel veiculo = JsonConvert.DeserializeObject<VeiculoModel>(dados);
                                    return Ok(veiculo);
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
