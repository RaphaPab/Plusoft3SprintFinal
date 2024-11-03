using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plusoft3Sprint.Models
{
    [Table("TB_ENDERECO_PLUS")]
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Rua{ get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public long Cep { get; set; }

    }
}
