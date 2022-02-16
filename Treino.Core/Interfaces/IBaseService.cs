using System.Collections.Generic;
using System.Threading.Tasks;

namespace Treino.Core.Interfaces
{
    public interface IBaseService<T> where T : IBaseEntity
    {
        Task<IEnumerable<T>> ListaAsync();

        Task<T> ObtemPorIdAsync(int id);

        Task<int> SalvaAsync(T entidade);

        Task<bool> ExcluiAsync(int id);

        Task<bool> ExisteAsync(int id);

        Task AtivaOuInativaAsync(int id);
    }
}