using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projet.Models
{
    public class Auteur
    {
                public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Taille Max 50 cc")]
        public string Nom { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Taille Max 50 cc")]
        public string Prenom { get; set; }

        public ICollection<Livre> Livres { get; set; }
    }
}