using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Plusoft3Sprint.Models
{
    [Table("TB_CLIENTE_PLUS")]
    public class Cliente
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DataNascimento { get; set; }

        [Required]
        public long CPF { get; set; }

        [Required]
        public string Telefone { get; set; }

        

    }
}
