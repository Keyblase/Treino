using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treino.Core.Entidades
{
    public class FilmeEntity : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Diretor { get; set; }
        public string Produtor { get; set; }
        public string Data_Lancamento { get; set; }
        public string Score { get; set; }
        public string Url { get; set; }

        //relações fk
        [NotMapped]
        public virtual ICollection<PessoaEntity> Pessoas { get; set; }
        [NotMapped]
        public virtual ICollection<EspecieEntity> Especies { get; set; }
        [NotMapped]
        public virtual ICollection<LocalEntity> Localizacoes { get; set; }
        [NotMapped]
        public virtual ICollection<VeiculoEntity> Veiculos { get; set; }
    }
}
