using System;
using System.Threading.Tasks;

namespace Treino.Core.Interfaces
{
    public interface IDadosRepositorio : IDisposable
    {
        //Instancia dinamica para os repositorios de dados
        IBaseRepositorio<T> Repositorio<T>() where T : class;
        // Método de Commit do contexto
        void SalvaTodos();
        // Método de Commit assincrono do contexto
        Task SalvaTodosAsync();
    }
}
