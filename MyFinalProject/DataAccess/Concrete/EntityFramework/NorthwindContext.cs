using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : DB tabloları ile proje classlarını bağlamak
    public class NorthwindContext:DbContext
    {
        //'override on' yaz enterla --> sonr sil bunu base.OnConfiguring(optionsBuilder);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;DataBase=Northwind;Trusted_Connection=true");// @ koyuduğun zman \ ' ı normal olarak algılar
            // Server:dan sonra ipde gelebilir
        }
        //prop TAB+TAB
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
