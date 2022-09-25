using EF_FinalyTask.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_FinalyTask
{
    public class Context: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public Context() 
        {

            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Data Source=ROMAN-DJOKER198; Database=EF; Encrypt=false;Integrated Security=true");
        }
    }
}
