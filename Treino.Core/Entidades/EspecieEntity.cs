using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Treino.Core.Entidades
{
    public class EspecieEntity
    {
        public string Nome { get; set; }
        public string Classificacao { get; set; }
        public string Cor_Olhos { get; set; }
        public string Cor_Cabelo { get; set; }
        [NotMapped]
        public virtual ICollection<PessoaEntity> Pessoas { get; set; }
        [NotMapped]
        public virtual ICollection<FilmeEntity> Filmes { get; set; }
        public string Url { get; set; }
    }
}
