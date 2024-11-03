using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plusoft3Sprint.Models
{
    [Table("TB_EMAIL_PLUS")]
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeEmail { get; set; }

        [Required]
        public string DescricaoEmail { get; set; }

    }
}
