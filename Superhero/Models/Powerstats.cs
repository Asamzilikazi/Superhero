using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superheroes.Models
{
    public class Powerstats 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("SuperheroId")]
        public string SuperheroId { get; set; }
        public string intelligence { get; set; }
        public string strength { get; set; }
        public string speed { get; set; }
        public string durability { get; set; }
        public string power { get; set; }
        public string combat { get; set; }
        // Navigation property to the Superhero entity
        
        public Superhero Superhero { get; set; }
    }
}
