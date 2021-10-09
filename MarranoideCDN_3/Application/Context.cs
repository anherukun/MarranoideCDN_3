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

        // public virtual DbSet<User> Users { get; set; }
        // public virtual DbSet<Employe> Employes { get; set; }

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

            // modelBuilder.Entity<User>().ToTable("Users");
            // modelBuilder.Entity<Employe>().ToTable("Employes");
            // modelBuilder.Entity<ObjectClass>().ToTable("TableName");
        }
    }
}
