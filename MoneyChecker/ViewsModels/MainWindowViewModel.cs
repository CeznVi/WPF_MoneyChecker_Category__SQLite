using MoneyChecker.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.ViewsModels
{

    public class MainWindowViewModel
    {
        private SQLiteDbContext _sQLiteDbContext;
        public CategoryViewModel CategoryViewModel;
        public MainWindowViewModel(SQLiteDbContext qLiteDbContext)
        {
            _sQLiteDbContext = qLiteDbContext;
            CategoryViewModel = new CategoryViewModel(_sQLiteDbContext);
        }
    }

}
