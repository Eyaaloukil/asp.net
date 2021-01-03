using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Models.Repositories
{
    public interface ILivreRepositorye
    {
        Livre GetLivre(int Id);
        IEnumerable<Livre> GetAllLivre();
        IEnumerable<Livre> GetLivreByCategory(int Id);

        Livre Add(Livre livre);
        Livre Update(Livre livreChanges);
        Livre Delete(int Id);

    }
}
