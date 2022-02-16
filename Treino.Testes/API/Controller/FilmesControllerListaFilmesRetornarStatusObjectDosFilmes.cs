using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Treino.API.Controllers;
using Treino.ViewModels;
using Xunit;

namespace Treino.TestesUnitarios.API.Controller
{
    public class FilmesControllerListaFilmesRetornarStatusObjectDosFilmes
    {
        FilmesApiController _filmesController;

        public FilmesControllerListaFilmesRetornarStatusObjectDosFilmes()
        {
            _filmesController = new FilmesApiController();
        }

        #region testes para dar como correto
        [Fact]
        public void Get_QuandoChamado_ReturnaObjectResult()
        {
            // Act
            var okResult = _filmesController.ListaFilmes();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_QuandoChamado_ReturnaTodosFilmes()
        {
            // Act
            var okResult = _filmesController.ListaFilmes();
            // Assert
            var items = Assert.IsType<List<FilmeModel>>(okResult.Result.Value);
            Assert.Equal(21, items.Count);
        }

        [Fact]
        public void Get_QuandoChamado_ReturnaAsInformacoesListaFilmes()
        {
            // Act
            var okResult = _filmesController.ListaFilmes();
            // Assert
            var item = Assert.IsType<List<FilmeModel>>(okResult.Result.Value);
            Assert.NotNull(item);
        }

        #endregion

        #region testes para dar erro
        [Fact]
        public void Get_QuandoChamado_ReturnaOkResultMensagemNaoEncontrado()
        {
            // Act
            var notFound = _filmesController.ListaFilmes();
            // Assert
            Assert.IsType<NotFoundObjectResult>(notFound.Result);
        }
        #endregion

        #region testes para dar excessoes
        [Fact]
        public void Get_QuandoChamado_ReturnaOkResultMensagemExcessao()
        {
            // Act
            var badRequest = _filmesController.ListaFilmes();
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, badRequest.Status.GetHashCode());
            Assert.IsType<ObjectResult>(badRequest.Result);
        }
        #endregion
    }
}
