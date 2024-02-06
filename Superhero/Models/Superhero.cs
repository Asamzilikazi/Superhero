using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superheroes.Models
{
    public class Superhero 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        public string name { get; set; }
        
        public Powerstats powerstats { get; set; }     
        public Biography biography { get; set; }      
        public Appearance appearance { get; set; }        
        public Work work { get; set; }   
        public Connections connections { get; set; }
        public Image image { get; set; }
        
    }
}
