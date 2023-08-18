using FichaCadastroApi.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FichaCadastroApi.Model
{
    [Table("Ficha")]
    public class FichaModel : RelacionalBase
    {
        [Column(TypeName = "VARCHAR"), Required, StringLength(250)]
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<DetalheModel> Detalhes { get; set; }

    }
}
