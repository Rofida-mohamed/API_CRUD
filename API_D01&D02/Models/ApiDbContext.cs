using Microsoft.EntityFrameworkCore;

namespace Api_D01.Models
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public ApiDbContext()
        {

        }

        public ApiDbContext(DbContextOptions options ) : base( options ) 
        { 

        }
        
    }
}
