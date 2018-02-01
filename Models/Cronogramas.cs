using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosLivre.Models
{
    public class Cronogramas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCronograma { get; set; }
        [Required]
        public int IdCurso { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DiaInicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DiaFim { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime HoraInicio { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime HoraFim { get; set; }

        public Cursos Cursos { get; set; }
        public ICollection<Dias> Dias {get;set;}
        
    }
}