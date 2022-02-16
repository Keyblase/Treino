using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Treino.Core.Entidades;
using Treino.Core.Interfaces;

namespace Treino.Core.Services
{
    public abstract class BaseService<T> : IDisposable, IBaseService<T> where T : BaseEntity
    {
        //Atributos
        private readonly IDadosRepositorio dadosRepositorio;

        //Metodos
        public BaseService(IDadosRepositorio dadosRepository)
        {
            this.dadosRepositorio = dadosRepository;
        }

        public Task AtivaOuInativaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
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

        public Task<IEnumerable<T>> ListaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> ObtemPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SalvaAsync(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
