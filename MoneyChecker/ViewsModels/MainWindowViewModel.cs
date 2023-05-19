using MoneyChecker.Entities;

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
