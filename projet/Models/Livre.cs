using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models
{
    public class ListeCat
    {
        
    }
    public class Livre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Taille Max 50 cc")]
        public string Name { get; set; }
                public Auteur Auteur { get; set; }     

        public Category Category { get; set; }     
        [Range(10, 500, ErrorMessage = "Doit être entre 10 et 500")]
        public int price { get; set; }
        public int CategoryId { get; set; }
           public int AuteurId { get; set; }

        public string PhotoPath { get; set; }
    }
}
