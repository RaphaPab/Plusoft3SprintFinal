using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plusoft3Sprint.Models
{
    [Table("TB_PRODUTO_PLUS")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeProduto { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)*")]
        public decimal Preco { get; set; }

        [Required]
        public string Tamanho { get; set; }

        [Required]
        public string SexoCliente { get; set; }

        [Required]
        public string EstacaoAno { get; set; }

        [Required]
        public string CorProduto { get; set; }


    }
}
