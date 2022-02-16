using System.Collections.Generic;

namespace Treino.Core.Entidades
{
    public class VeiculoEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Classe_Veiculo { get; set; }
        public string Comprimento { get; set; }
        public string Titulo { get; set; }
        //[NotMapped]
        public virtual PessoaEntity Piloto { get; set; }
        //[NotMapped]
        public virtual ICollection<FilmeEntity> Filmes { get; set; }
        public string Url { get; set; }

    }
}
