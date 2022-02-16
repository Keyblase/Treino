using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Treino.ViewModels;
using Xunit;

namespace Treino.TestesUnitarios.API.Controller
{
    public class FilmesControllerListaFilmesIdRetornarStatusObjectDosFilmes
    {
        FilmesApiController _filmesController;

        public FilmesControllerListaFilmesIdRetornarStatusObjectDosFilmes()
        {
            _filmesController = new FilmesApiController();
        }

        #region testes para dar como correto
        [Theory]
        [InlineData("2baf70d1-42bb-4437-b551-e5fed5a87abe")]
        [InlineData("12cfb892-aac0-4c5b-94af-521852e46d6a")]
        public void Get_QuandoChamado_ReturnaObjectResult(string id)
        {
            // Act
            var okResult = _filmesController.ListaFilme(id);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Theory]
        [InlineData("2baf70d1-42bb-4437-b551-e5fed5a87abe")]
        [InlineData("12cfb892-aac0-4c5b-94af-521852e46d6a")]
        public void Get_QuandoChamado_ReturnaAsInformacoesFilmeId(string id)
        {
            // Act
            var okResult = _filmesController.ListaFilme(id);
            // Assert
            var item = Assert.IsType<FilmeModel>(okResult.Result.Value);
            Assert.NotNull(item);
        }
        #endregion

        #region testes para dar erro
        [Theory]
        [InlineData("1")]
        [InlineData("12cfb892-aasd0-4c5b-94af-521852e46d93")]
        [InlineData("naoVaiFuncionar!")]
        public void Get_QuandoChamado_ReturnaOkResultMensagemNaoEncontrado(string id)
        {
            // Act
            var notFound = _filmesController.ListaFilme(id);
            // Assert
            Assert.IsType<NotFoundObjectResult>(notFound.Result);
        }
        #endregion

        #region testes para dar excessoes
        [Theory]
        [InlineData("2baf70d1-42bb-4437-b551-e5fed5a87abe")]
        [InlineData("12cfb892-aac0-4c5b-94af-521852e46d6a")]
        public void Get_QuandoChamado_ReturnaOkResultMensagemExcessao(string id)
        {
            // Act
            var badRequest = _filmesController.ListaFilme(id);
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, badRequest.Status.GetHashCode());
            Assert.IsType<BadRequestObjectResult>(badRequest.Result);
        }
        #endregion
    }
}
