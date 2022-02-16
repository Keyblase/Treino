using System;
using System.Collections.Generic;
using System.Text;

namespace Treino.Core.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        bool Inativo { get; set; }
        DateTime Inclusao { get; set; }
    }
}
