using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Treino.Core.Entidades;
using Treino.Core.Interfaces;

namespace Treino.Core.Services
{
    public class FilmeService : IFilmesService /* BaseService<FilmeEntity>, */
    {
        //private readonly IDadosRepositorio _repositorio;

        public FilmeService(/*IDadosRepositorio repositorio) : base(repositorio*/)
        {
            //this._repositorio = repositorio;
        }

        public FilmeEntity Add(FilmeEntity novoFilme)
        {
            throw new NotImplementedException();
        }

        public Task AtivaOuInativaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluiAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilmeEntity> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public FilmeEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UsuarioEntity>> ListaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEntity> ObtemPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SalvaAsync(UsuarioEntity entidade)
        {
            throw new NotImplementedException();
        }
    }
}
