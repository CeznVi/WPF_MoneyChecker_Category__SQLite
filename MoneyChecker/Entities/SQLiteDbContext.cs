using Microsoft.EntityFrameworkCore;
using System;

namespace MoneyChecker.Entities
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }

        private string _dbFilePath;
        public SQLiteDbContext(string dbPath)
        {
            _dbFilePath = dbPath;

            //Database.EnsureDeleted(); //удалить БД
            //Database.EnsureCreated(); //создать БД по шаблону
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbFilePath}");           //файл базы данных
        }

        /// <summary>
        /// Перегрузка метода шаблоного создания БД
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Развертывание бд
            Category[] categories = new Category[]
            {
                new Category(){Id = 1, Title = "Питание", Description = ""},
                new Category(){Id = 2, Title = "Проезд", Description = ""},
                new Category(){Id = 3, Title = "Личные траты", Description = ""},
                new Category(){Id = 4, Title = "Медицина", Description = ""},
                new Category(){Id = 5, Title = "Авто траты", Description = ""},
                new Category(){Id = 6, Title = "Коммунальные платежи", Description = ""},
                new Category(){Id = 7, Title = "Вода", Description = "", ParentId = 6},
                new Category(){Id = 8, Title = "Горячая вода", Description = "", ParentId = 7},
                new Category(){Id = 9, Title = "Холодная вода", Description = "", ParentId = 7},
                new Category(){Id = 10, Title = "Техническая вода", Description = "", ParentId = 7},
            };
            modelBuilder.Entity<Category>().HasData(categories);


            User[] users = new User[]
            {
                new User(){Id = 1, Email = "admin@admin.com", Password = ""},
                new User(){Id = 2, Email = "alex@alex.com", Password = ""},
                new User(){Id = 3, Email = "margaret@margaret.com", Password = ""},
            };
            modelBuilder.Entity<User>().HasData(users);


            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(k => k.Id).HasName("PK_Category");
                c.Property(k => k.Id).ValueGeneratedOnAdd();
                c.Property(k => k.Title).IsRequired().HasMaxLength(32);
                c.Property(k => k.ImgSrc).HasDefaultValue("/images/defaultCategory.png");
            });


            UserInfo[] usersInfo = new UserInfo[]
            {
                new UserInfo(){Id = 1, Fio = "Администратор Администр Администратович", BirthDate = new DateTime(2000, 5, 25), UserId = 1 },
                new UserInfo(){Id = 2, Fio = "Алекс Слексов Алексеевич", BirthDate = new DateTime(1985, 08, 11), UserId = 2 },
                new UserInfo(){Id = 3, Fio = "Маргарет Тхетчер Маргаруитовна", BirthDate = new DateTime(2004, 4, 16), UserId = 3 },
            };
            modelBuilder.Entity<UserInfo>().HasData(usersInfo);

            modelBuilder.Entity<UserInfo>(ui =>
            {
                ui.HasKey(k => k.Id).HasName("PK_UserInfo");
                ui.Property(k => k.Id).ValueGeneratedOnAdd();
                ui.Property(k => k.Fio).IsRequired().HasMaxLength(128);
                ui.Property(k => k.BirthDate).HasDefaultValue(DateTime.Now);

                modelBuilder.Entity<UserInfo>().HasOne(u => u.User).WithMany().HasForeignKey(u => u.UserId);
            });
        }
    }


}
