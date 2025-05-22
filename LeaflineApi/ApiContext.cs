using LeaflineApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaflineApi
{
  public class ApiContext : DbContext
  {
    
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) {
      
    }

    public DbSet<LeaflineUser> users { get; set; }
    public DbSet<LeaflineDispensary> dispensaries { get; set; }

    public DbSet<LeaflineTag> tags { get; set; }

    public DbSet<LeaflineTagEntry> tagEntries { get; set; }


  }
}
