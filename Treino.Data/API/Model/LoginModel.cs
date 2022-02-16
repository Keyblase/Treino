using System;
using System.Collections.Generic;
using System.Text;
using Treino.Data.API.Model;

namespace Treino.Data.API.Model
{
    public class LoginModel
    {
        public UsuarioModel Usuario { get; set; }

        public string Token { get; set; }
    }
}
