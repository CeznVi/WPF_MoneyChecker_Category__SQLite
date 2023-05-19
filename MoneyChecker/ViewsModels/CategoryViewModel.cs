using MoneyChecker.Entities;
using MoneyChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.ViewsModels
{
    public class CategoryViewModel
    {
        private SQLiteDbContext _sQLiteDbContext;
        public CategoryModel CategoryModel;
        public CategoryViewModel(SQLiteDbContext qLiteDbContext)
        {
            _sQLiteDbContext = qLiteDbContext;
            CategoryModel = new CategoryModel(_sQLiteDbContext);
        }
        public List<Category> DataSource
        {
            get { return CategoryModel.GetAllCategories(); }
        }
    }
}
