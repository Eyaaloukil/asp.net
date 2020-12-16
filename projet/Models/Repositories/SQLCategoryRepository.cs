using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace projet.Models.Repositories
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public SQLCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Category Add(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
            return category;
        }

        public Category Delete(int Id)
        {
            Category category = context.Category.Find(Id);
            if (category != null)
            {
                context.Category.Remove(category);
                context.SaveChanges();
            }
            return category;
        }
        public IEnumerable<Category> GetAllCategory()
        {
            return context.Category;
        }

        public Category GetCategory(int Id)
        {
            return context.Category.Find(Id);
        }

        public Category Update(Category categoryChanges)
        {
            var category = context.Category.Attach(categoryChanges);
            category.State = EntityState.Modified;
            context.SaveChanges();
            return categoryChanges;
        }

        
        Category ICategoryRepository.GetCategory(int Id)
        {
                        return context.Category.Find(Id);

        }
    }


    }
