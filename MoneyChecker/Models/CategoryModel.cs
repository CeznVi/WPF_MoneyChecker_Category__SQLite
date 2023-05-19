using MoneyChecker.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MoneyChecker.Models
{
    public class CategoryModel
    {
        private SQLiteDbContext _dbContext;

        public CategoryModel(SQLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.OrderBy(c => c.Id).ToList();
        }
        public Category GetCategoryById(int Id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.Id == Id);
        }

        public bool AddNewCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            return _dbContext.SaveChanges() == 1 ? true : false;                   //синхронизация - сохранение в файл
        }

        public List<Category> GoDownCategories(int? parentId = null)
        {

            List<Category> result = new List<Category>();

            foreach (Category subCat in _dbContext.Categories.Where(c => c.ParentId == parentId))
            {
                result.Add(subCat);
                subCat.SubCategories = new List<Category>();
                subCat.SubCategories.AddRange(GoDownCategories(subCat.Id));
            }
            return result;
        }




    }

}
