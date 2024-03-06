using Microsoft.EntityFrameworkCore;
using to_do.Models;

namespace to_do.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> CATEGORIES { get; set; }
    }

    

}
