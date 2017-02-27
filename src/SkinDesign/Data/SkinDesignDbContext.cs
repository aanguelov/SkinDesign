using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkinDesign.Entities;

namespace SkinDesign.Data
{
    public class SkinDesignDbContext : IdentityDbContext<User>
    {
        public SkinDesignDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Procedure> Procedures { get; set; }
    }
}
