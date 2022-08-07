using Microsoft.EntityFrameworkCore;

namespace ClassRoomAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        }
        public DbSet<Student> Classes { get; set; }
    }
}
