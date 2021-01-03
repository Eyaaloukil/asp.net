using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace projet.Models.Repositories
{
    public class SQLEmpruntRepository : IEmpruntRepository
    {
        private readonly AppDbContext context;
        public SQLEmpruntRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Emprunt Add(Emprunt emprunt)
        {
            context.Emprunt.Add(emprunt);
            context.SaveChanges();
            return emprunt;
        }

        public Emprunt Delete(int Id)
        {
            Emprunt emprunt = context.Emprunt.Find(Id);
            if (emprunt != null)
            {
                context.Emprunt.Remove(emprunt);
                context.SaveChanges();
            }
            return emprunt;
        }

        public IEnumerable<Emprunt> GetAllEmprunts()
        {
            return context.Emprunt.Include("Livre");
        }

        public IEnumerable<Emprunt> GetEmpruntsByUser(int Id)
        {
            return context.Emprunt.Where(x=>x.UserId==Id).Include("Livre");
        }
    }
}