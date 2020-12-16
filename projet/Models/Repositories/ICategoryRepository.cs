using System.Collections.Generic;

namespace projet.Models.Repositories
{
    public interface ICategoryRepository
    {
          Category GetCategory(int Id);
        IEnumerable<Category> GetAllCategory();
        Category Add(Category category);
        Category Update(Category categoryChanges);
        Category Delete(int Id);
    }
}