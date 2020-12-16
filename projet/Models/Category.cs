using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projet.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Taille Max 50 cc")]
        public string Name { get; set; }
        public ICollection<Livre> Livres { get; set; }
    }
}