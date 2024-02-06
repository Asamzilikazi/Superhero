
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Superheroes.Models
{
    public class Connections 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        // Foreign key property
        [ForeignKey("SuperheroId")]
        public string SuperheroId { get; set; }
        public string groupAffiliation { get; set; }
        public string relatives { get; set; }

        // Navigation property to the Superhero entity
       
        public Superhero Superhero { get; set; }
    }
}
