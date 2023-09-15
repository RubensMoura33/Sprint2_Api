using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.code.First.manha.Domains
{
    //Classe que representa a entidade jogo
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do jogo e obrigatorio!")]
        public string?  Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lancamento obrigatorio!")]
        public DateTime DataLancamento { get; set; }


        [Column(TypeName = "DECIMAL(4,2)")]
        [Required(ErrorMessage ="Preco do jogo e obrigatorio ")]
        public decimal preco { get; set; }


        [Required(ErrorMessage = "Informe o estudio que produxziu o jogo")]
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }



    }
}
