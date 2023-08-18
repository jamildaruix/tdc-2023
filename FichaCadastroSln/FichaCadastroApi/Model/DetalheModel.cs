using FichaCadastroApi.Base;
using FichaCadastroApi.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FichaCadastroApi.Model
{
    [Table("Detalhe")]
    public class DetalheModel : RelacionalBase
    {
       

        [Column(TypeName = "VARCHAR"), Required, StringLength(500)]
        public string? Feedback { get; set; }

        [Required]
        public NotaEnum Nota { get; set; }

        [Required]
        public bool Ativado { get; set; }

        [Required]
        public virtual FichaModel Ficha { get; set; }
    }
}
