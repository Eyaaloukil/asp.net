using System.Collections.Generic;

namespace projet.Models.Repositories
{
    public interface IAuteurRepository
    {
         
          Auteur GetAuteur(int Id);
        IEnumerable<Auteur> GetAllAuteurs();
        Auteur Add(Auteur auteur);
        Auteur Update(Auteur auteurChanges);
        Auteur Delete(int Id);
    }
}