﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.code.First.manha.Domains
{

    [Table("Estudio")]
    public class Estudio
    {

        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do estudio obrigatorio!")]
        public string? Nome { get; set; }

        public List<Jogo>? Jogo { get; set; }
    }
}
