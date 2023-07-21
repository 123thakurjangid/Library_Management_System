using LibraryManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.DbContexts
{
    public class BookDbContexts : DbContext
    {
        public BookDbContexts() : base() 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=LibraryManagement;Trusted_Connection=True;Encrypt=Yes;TrustServerCertificate=Yes");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Books> Books { get; set; }
    }
}
