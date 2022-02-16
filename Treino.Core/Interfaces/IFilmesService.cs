using System.Collections.Generic;
using Treino.Core.Entidades;

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
