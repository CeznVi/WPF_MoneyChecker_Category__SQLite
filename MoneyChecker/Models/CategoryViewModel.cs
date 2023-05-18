using MoneyChecker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.Models
{
    class CategoryViewModel
    {
        private SQLiteDbContext _sQLiteDbContext;

        public CategoryViewModel(SQLiteDbContext sQLiteDbContext)
        {
            _sQLiteDbContext = sQLiteDbContext;

        }
    }
}
