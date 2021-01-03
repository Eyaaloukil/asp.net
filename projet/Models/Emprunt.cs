using System;

namespace projet.Models
{
    public class Emprunt
    {
        public int Id { get; set; }
        public Livre Livre { get; set; }

        public int LivreId { get; set; }
        public int UserId { get; set; }
        
        public DateTime DateRetour { get;set; }
    }
}