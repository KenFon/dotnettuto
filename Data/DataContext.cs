using Microsoft.EntityFrameworkCore;
using testapi.Models;

namespace testapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options){}
        public DbSet<Car> Cars { get; set; }
    }
} 