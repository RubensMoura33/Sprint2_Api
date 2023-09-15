using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.code.First.manha.Domains
{
    
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]//Cria um indice unico para
    
    public class Usuario
    {
        

        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Email obrigatorio")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage ="Senha obrigatoria")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Senha de 6 a 20 caracteres")]
        public string? Senha { get; set; }

        //Referencia da Chave estrangeira (Tabela de TipoUsuario)
        [Required(ErrorMessage = "Tipo de usuario Obrigatorio")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
