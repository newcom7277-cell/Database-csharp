using Microsoft.EntityFrameworkCore;
using metermngemen.Models;

namespace metermngemen.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<MeterInfo> MeterInfos {get;set;}
}
