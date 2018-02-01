using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosLivre.Models
{
    public class Dias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDias { get; set; }
        [Required]
        public int IdCronograma { get; set; }
        [Required]
        public string Dia { get; set; }
        public Cronogramas Cronogramas { get; set; }
    }
}