using Microsoft.EntityFrameworkCore;

namespace HomeRent.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Mentor> Mentors { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }
    }
}
