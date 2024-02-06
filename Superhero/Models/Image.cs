
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Superheroes.Models
{
    public class Image 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("SuperheroId")]
        public string SuperheroId { get; set; }
        public string url { get; set; }
        // Navigation property to the Superhero entity
       
        public Superhero Superhero { get; set; }
    }
}
