using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Superheroes.Models
{
    public class Appearance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        // Foreign key property
        [ForeignKey("SuperheroId")]
        public string SuperheroId { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        [NotMapped]
        public List<string> height { get; set; }
        [NotMapped]
        public List<string> weight { get; set; }
        public string eyeColor { get; set; }
        public string hairColor { get; set; }
        // Navigation property to the Superhero entity
        
        public Superhero Superhero { get; set; }

    }
}
