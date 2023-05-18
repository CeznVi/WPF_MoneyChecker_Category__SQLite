using MoneyChecker.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyChecker.ViewsModels
{

    /*  NEEED COPY PAST  */
    class MainWindowViewModel
    {
        private SQLiteDbContext _sQLiteDbContext;

        public MainWindowViewModel(SQLiteDbContext sQLiteDbContext)
        {
            _sQLiteDbContext = sQLiteDbContext;


        }
    }
}
