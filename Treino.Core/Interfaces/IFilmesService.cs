using System;
using System.Collections.Generic;
using System.Text;
using Treino.Core.Entidades;
using Treino.ViewModels;

namespace Treino.Core.Interfaces
{
    public interface IFilmesService : IBaseService<UsuarioEntity>
    {
        IEnumerable<FilmeEntity> GetAllItems();
        FilmeEntity Add(FilmeEntity novoFilme);
        FilmeEntity GetById(int id);
        void Remove(int id);
    }
}
