using System.Collections.Generic;

namespace projet.Models.Repositories
{
    public interface IEmpruntRepository
    {
          IEnumerable<Emprunt> GetAllEmprunts();
        IEnumerable<Emprunt> GetEmpruntsByUser(int Id);

        Emprunt Add(Emprunt emprunt);
        Emprunt Delete(int Id);
    }
}