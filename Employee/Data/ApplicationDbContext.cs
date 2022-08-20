using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Staff> Staffs { get; set; } = null!;
    }
}
