using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace projet.Models.Repositories
{
    public class SQLLivreRepository : ILivreRepositorye
    {
        private readonly AppDbContext context;

        public SQLLivreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Livre Add(Livre livre)
        {
            context.Livre.Add(livre);
            context.SaveChanges();
            return livre;
        }

        public Livre Delete(int Id)
        {
            Livre livre = context.Livre.Find(Id);
            if (livre != null)
            {
                context.Livre.Remove(livre);
                context.SaveChanges();
            }
            return livre;
        }
        public IEnumerable<Livre> GetAllLivre()
        {
            return context.Livre;
        }

        public Livre GetLivre(int Id)
        {
            return context.Livre.Find(Id);
        }

        public Livre Update(Livre livreChanges)
        {
            var livre = context.Livre.Attach(livreChanges);
            livre.State = EntityState.Modified;
            context.SaveChanges();
            return livreChanges;
        }
    }


}

