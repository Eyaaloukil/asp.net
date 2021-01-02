using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace projet.Models.Repositories
{
    public class SQLAuteurRepository: IAuteurRepository
    {
        private readonly AppDbContext context;

        public SQLAuteurRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Auteur Add(Auteur auteur)
        {
            context.Auteur.Add(auteur);
            context.SaveChanges();
            return auteur;
        }


        public IEnumerable<Auteur> GetAllAuteurs()
        {
            return context.Auteur;
        }

      

        public Auteur GetAuteur(int Id)
        {
            return context.Auteur.Find(Id);
        }

   


        public Auteur Update(Auteur auteurChanges)
        {
 var auteur = context.Auteur.Attach(auteurChanges);
            auteur.State = EntityState.Modified;
            context.SaveChanges();
            return auteurChanges;        }

        Auteur IAuteurRepository.Delete(int Id)
        {
Auteur auteur = context.Auteur.Find(Id);
            if (auteur != null)
            {
                context.Auteur.Remove(auteur);
                context.SaveChanges();
            }
            return auteur;        }

    }


    }
