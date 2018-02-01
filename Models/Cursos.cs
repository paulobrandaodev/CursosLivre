using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosLivre.Models
{
    public class Cursos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }
        [Required]
        public int IdArea { get; set; }
        [Required]
        public string Curso { get; set; }

        public Areas Areas{get;set;}
        public ICollection<Cronogramas> Cronogramas {get;set;}


    }
}