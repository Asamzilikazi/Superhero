using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superheroes.Models
{
    public class Work 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("SuperheroId")]
        public string SuperheroId { get; set; }
        public string occupation { get; set; }
        [JsonProperty("base")]
        public string Base { get; set; }
        // Navigation property to the Superhero entity
        
        public Superhero Superhero { get; set; }

    }
}
