using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treino.Core.Entidades
{
    public class LocalEntity
    {
        public string Nome { get; set; }
        public string Clima { get; set; }
        public string Terreno { get; set; }
        public string Agua_Superficie { get; set; }
        [NotMapped]
        public ICollection<PessoaEntity> Residentes { get; set; }
        [NotMapped]
        public virtual ICollection<FilmeEntity> Filmes { get; set; }
        public string Url { get; set; }
    }
}
