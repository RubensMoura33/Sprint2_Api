using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O Titulo do filme e obrigatorio")]
        public string? Titulo { get; set; }
        public GeneroDomain Genero { get; set; }


    }
}
