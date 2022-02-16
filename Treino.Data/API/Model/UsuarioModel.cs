using System;
using Treino.Core.Entidades;

namespace Treino.Data.API.Model
{
    public class UsuarioModel : BaseEntity
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

    }
}
