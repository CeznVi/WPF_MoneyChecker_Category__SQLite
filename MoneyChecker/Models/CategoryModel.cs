using MoneyChecker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Models
{
    class CategoryModel
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


        public Category GetCategoryById(int id) 
        { 
            return _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public bool AddNewCategory(Category category) 
        { 
            _dbContext.Categories.Add(category);
            return _dbContext.SaveChanges() == 1 ? true : false;

        }

        public List<Category> GoDownCategorise(int? parentId = null)
        {
            List<Category> rezult = new List<Category>();

            foreach (Category subCategory in _dbContext.Categories.Where(c => c.ParrentId == parentId))
            {
                rezult.Add(subCategory);
                subCategory.SubCategories = new List<Category>();
                subCategory.SubCategories.AddRange(GoDownCategorise(subCategory.Id));

            }

            return rezult;
        }


    }
}
