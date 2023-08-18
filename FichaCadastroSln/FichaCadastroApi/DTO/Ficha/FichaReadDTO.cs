using FichaCadastroApi.Base;
using FichaCadastroApi.Enumerators;

namespace FichaCadastroApi.DTO.Ficha
{
    public class FichaReadDTO : DTOBase 
    {
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public IList<FichaDetalheReadDTO>? FichaComDetalhes  { get; set; }
    }

    public class FichaDetalheReadDTO : DTOBase 
    {
        public NotaEnum Numero { get; set; }
        public string Justificativa { get; set; }
    }
}
