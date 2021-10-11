using MarranoideCDN_3.Models;
using MarranoideCDN_3.Models.Minecraft;
using MarranoideCDN_3.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarranoideCDN_3.Application
{
    public class Context : DbContext
    {
        // .NET CLI
        // dotnet ef migrations add [Nombre de migracion]
        // dotnet ef database update

        // public virtual DbSet<ObjectClass> Object { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<UserRol> UserRols { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Item> MinecraftItems { get; set; }
        public virtual DbSet<EnchantCategory> MinecraftEnchantCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseMySQL("server=localhost; port=3306; database=MarranoideCDN-DEBUG; user=root; password=Ragnarok1");
#else
            optionsBuilder.UseMySQL("server=localhost; port=3306; database=MarranoideCDN-PROD; user=root; password=Ragnarok1");
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRol>().ToTable("UserRols");
            modelBuilder.Entity<UserRol>().HasIndex(x => x.UserLevel).IsUnique();
            SeedUserRols(modelBuilder);

            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Account>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(x => x.Username).IsUnique();
            SeedAccounts(modelBuilder);

            modelBuilder.Entity<Session>().ToTable("Sessions");

            modelBuilder.Entity<Item>().ToTable("MinecraftItems");
            modelBuilder.Entity<Item>().HasIndex(x => x.ItemIndex).IsUnique();
            modelBuilder.Entity<Item>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<EnchantCategory>().ToTable("MinecraftEnchantCategories");
            modelBuilder.Entity<EnchantCategory>().HasIndex(x => x.Name).IsUnique();
        }

        private void SeedUserRols(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRol>().HasData(
                new UserRol { IDUserRol = "25DF3DC8-E441-443C-BDBB-EB8199FA7FFA", UserLevel = 1, UserRolName = "User", UserRolPermisions = "+ Acceso a funciones GET del API" },
                new UserRol { IDUserRol = "29F858BF-BEA3-48CA-B4F2-876BF3469B4F", UserLevel = 2, UserRolName = "Developer", UserRolPermisions = "+ Acceso a funciones GET del API\n+ Acceso a funciones POST del API" },
                new UserRol { IDUserRol = "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", UserLevel = 10, UserRolName = "SuperU", UserRolPermisions = "+ Acceso a funciones GET del API\n+ Acceso a funciones POST del API\n+ Acceso a consola de administracion del CDN" }
                );
            // RepoUserRols.AddOrUpdate(new UserRol { IDUserRol = "25DF3DC8-E441-443C-BDBB-EB8199FA7FFA", UserLevel = 1, UserRolName = "User", UserRolPermisions = "+ Acceso a funciones GET del API" });
            // RepoUserRols.AddOrUpdate(new UserRol { IDUserRol = "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", UserLevel = 10, UserRolName = "Developer", UserRolPermisions = "+ Acceso a funciones GET del API\n+Acceso a funciones POST del API" });
        }
        private void SeedAccounts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account { IDAccount = "66CA7A17-E182-498F-AC3C-7AC25AD7ACD1", Username = "User1", Email = "example1@email.com", IDUserRol = "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", PasswordHash = Security.SHA256Hash("Hola100"), CreatedAt = DateTime.Now },
                new Account { IDAccount = "62F36B2A-F1F8-4399-942F-4190771F9FCD", Username = "User2", Email = "example2@email.com", IDUserRol = "29F858BF-BEA3-48CA-B4F2-876BF3469B4F", PasswordHash = Security.SHA256Hash("Hola100"), CreatedAt = DateTime.Now },
                new Account { IDAccount = "8A5AC66A-C705-471F-B508-66D4A036176D", Username = "User3", Email = "example3@email.com", IDUserRol = "29F858BF-BEA3-48CA-B4F2-876BF3469B4F", PasswordHash = Security.SHA256Hash("Admin100"), CreatedAt = DateTime.Now },
                new Account { IDAccount = "513E4F4B-2360-40EC-B342-33A043AB02EA", Username = "Mithyck", Email = "angel.g.j.reyes@gmail.com", IDUserRol = "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", PasswordHash = Security.SHA256Hash("Doodlebundleapi"), CreatedAt = DateTime.Now }
                );
            // RepoAccounts.AddOrUpdate(new Account { IDAccount = "513E4F4B-2360-40EC-B342-33A043AB02EA", Username = "User1", IDUserRol = "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", PasswordHash = Security.SHA256Hash("Hola100"), CreatedAt = DateTime.Now });
            // RepoAccounts.AddOrUpdate(new Account { IDAccount = "513E4F4B-2360-40EC-B342-33A043AB02EA", Username = "Admin", IDUserRol = "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", PasswordHash = Security.SHA256Hash("Admin100"), CreatedAt = DateTime.Now });
            // RepoAccounts.AddOrUpdate(new Account { IDAccount = "513E4F4B-2360-40EC-B342-33A043AB02EA", Username = "Mithyck", IDUserRol = "DA1D0C4A-1D4E-4B56-939E-AB9548DE5352", PasswordHash = Security.SHA256Hash("Doodlebundleapi"), CreatedAt = DateTime.Now });
        }
    }
}
