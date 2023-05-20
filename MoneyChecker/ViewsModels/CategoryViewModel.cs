using MoneyChecker.Entities;
using MoneyChecker.Models;
using System.Collections.Generic;

namespace MoneyChecker.ViewsModels
{
    public class CategoryViewModel
    {
        private SQLiteDbContext _sQLiteDbContext;
        public CategoryModel CategoryModel;

        /*------------------------------------ Конструкторы ------------------------------------*/
        public CategoryViewModel(SQLiteDbContext qLiteDbContext)
        {
            _sQLiteDbContext = qLiteDbContext;
            CategoryModel = new CategoryModel(_sQLiteDbContext);
        }

        /*------------------------------------ Свойства ------------------------------------*/
        public List<Category> DataSource
        {
            get 
            {
                return CategoryModel.GetAllCategories(); 
            }
        }

        public List<Category> GetOnlyCategories
        {
            get
            {
                CategoryModel.GoDownCategories();
                return CategoryModel.GetAllCategoriesWithoutSubCategory();
            }
        }

    }
}
