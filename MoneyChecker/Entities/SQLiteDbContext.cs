using Microsoft.EntityFrameworkCore;
using System;

namespace MoneyChecker.Entities
{
    class SQLiteDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserInfo> UsersInfo { get; set; }

        private string _dbFilePath;


        /*  CTOR  */
        public SQLiteDbContext(string dbPath)
        {
            _dbFilePath = dbPath;
            Database.EnsureDeleted();
            Database.EnsureCreated();

        }



        /* OVERRIDE */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite($"Filename={_dbFilePath}"); //file bd

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            Category[] categories = new Category[]
            {
                new Category() {Id =1, Title = "Питание", Description = ""},
                new Category() {Id =2, Title = "Проезд", Description = ""},
                new Category() {Id =3, Title = "Личные траты", Description = ""},
                new Category() {Id =4, Title = "Медецина", Description = ""},
                new Category() {Id =5, Title = "Автомобильные траты", Description = ""},
                new Category() {Id =6, Title = "Комунальные платежи", Description = ""},

                  new Category() {Id =7, Title = "Вода", Description = "", ParrentId = 6},
                  new Category() {Id =8, Title = "Горячая вода", Description = "", ParrentId = 6},
                  new Category() {Id =9, Title = "Холодная вода", Description = "", ParrentId = 6},
                  new Category() {Id =10, Title = "Водоотвод холодной воды", Description = "", ParrentId = 6},


            };

            modelBuilder.Entity<Category>().HasData(categories);

            User[] users = new User[]
            {
                new User() {Id =1, Email = "admin@gmail.com", Password = "password123"},
                new User() {Id =2, Email = "Alex@gmail.com", Password = "passwod123"},
                new User() {Id =3, Email = "Sofi@gmail.com", Password = "pass3123"}
            };

            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<Category>(c =>
            {
                c.HasKey(k => k.Id).HasName("PK_Category");
                c.Property(k => k.Id).ValueGeneratedOnAdd();
                c.Property(k => k.Title).IsRequired().HasMaxLength(32);
                c.Property(k => k.ImgSrc).HasDefaultValue("/images/defaulCategory.png");

            });


            /////////////////SM PARY need copypast
            UserInfo[] userInfos = new UserInfo[]
            {
                new UserInfo() {Id =1, Fio = "Admin Adminov Adm", BirthDate = new DateTime(2000, 6, 24), UserId = 1},
                new UserInfo() {Id =2, Fio = "Uset Userovich", BirthDate = new DateTime(2004, 8, 24), UserId = 2},
                new UserInfo() {Id =3, Fio = "Atrem Artemovich Guzes", BirthDate = new DateTime(2004, 8, 24), UserId = 3},

            };

            modelBuilder.Entity<UserInfo>().HasData(userInfos);

            modelBuilder.Entity<UserInfo>(ui =>
             { 
                 ui.HasKey(k => k.Id).HasName("PK_UsersInfo");
                 //ui.Property(k => k.Id).ValueGenerata
             
             });


        }





    }

}
