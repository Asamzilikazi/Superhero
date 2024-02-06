using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Superheroes.Models
{
    public class Biography 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("SuperheroId")]
        public string SuperheroId { get; set; }
        public string fullName { get; set; }
        public string alterEgos { get; set; }
        [NotMapped]
        public List<string> aliases { get; set; }
        public string placeOfBirth { get; set; }
        public string firstAppearance { get; set; }
        public string publisher { get; set; }
        public string alignment { get; set; }

        // Navigation property to the Superhero entity
        
        public Superhero Superhero { get; set; }
    }
}
