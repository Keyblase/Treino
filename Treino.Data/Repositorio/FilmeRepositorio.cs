using System;
using System.Linq;
using System.Linq.Expressions;
using Treino.Core.Entidades;
using Treino.Core.Interfaces;

namespace Treino.Data.Repositorio
{
    public class FilmeRepositorio : IFilmeRepositorio
    {
        public void Adicionar(FilmeEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(FilmeEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Deletar(Func<FilmeEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<FilmeEntity> Get(Expression<Func<FilmeEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FilmeEntity> GetTodos()
        {
            throw new NotImplementedException();
        }

        public FilmeEntity Primeiro(Expression<Func<FilmeEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public FilmeEntity Procurar(params object[] key)
        {
            throw new NotImplementedException();
        }
    }
}
