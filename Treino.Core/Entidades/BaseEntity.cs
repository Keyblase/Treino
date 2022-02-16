using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Treino.Core.Interfaces;

namespace Treino.Core.Entidades
{
    public abstract class BaseEntity : IBaseEntity
    {
        //Propriedades
        //Chave pk
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        public bool Inativo { get; set; }

        [Display(Name = "Data de inclusão")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Inclusao { get; set; }

        //Metodos
        public BaseEntity()
        {
            Inativo = false;
            Inclusao = DateTime.Now;
        }
    }
}
