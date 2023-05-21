using Microsoft.EntityFrameworkCore;
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
            GoDownCategories();
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

        public bool DeleteCategory(Category category) 
        {

            ///Удалить вложеность
            if(category.SubCategories.Count > 0) 
            {
                foreach (var item in category.SubCategories)
                {
                    _dbContext.Categories.Remove(item);
                }
            }

            _dbContext.Categories.Remove(category);
            return _dbContext.SaveChanges() == 1 ? true : false;                   //синхронизация - сохранение в файл

        }

        public bool EditCategory(Category category)
        {
            _dbContext.Categories.Update(category);
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

        public List<Category> GetAllCategoriesWithoutSubCategory()
        {
            return _dbContext.Categories.Where(c => c.ParentId == null).ToList();
        }

        public int GetNextId()
        {
            //return _dbContext.Categories.Find( c=> c.id > _)
            return _dbContext.Categories.Count() + 1;
        }



    }

}
