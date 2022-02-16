using System;
using System.Collections.Generic;
using System.Linq;
using Treino.Data.API.Model;

namespace Treino.Data.API.Repositories
{
    public static class UsuarioRepository
    {
        public static UsuarioModel Get(string nomeDoUsuario,string senha)
        {
            var usuarios = new List<UsuarioModel>();
            usuarios.Add(new UsuarioModel { Id = new Guid(), Nome = "Nicolas" , Senha ="senhaForte", Role="administrador"});
            usuarios.Add(new UsuarioModel { Id = new Guid(), Nome = "Ana", Senha = "senhaForte123", Role = "colaborador" });

            var usuario = usuarios.Where(x => x.Nome.ToLower() == nomeDoUsuario.ToLower()
                                    && x.Senha == senha).First();

            if (usuario != null)
            {
                return usuario;
            }
            return null;
        }
    }
}
