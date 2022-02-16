using System;

namespace Treino.Core.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        bool Inativo { get; set; }
        DateTime Inclusao { get; set; }
    }
}
