using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainHoppers.Core.Domain;

namespace TrainHoppers.Data
{
    public class TrainHoppersContext : IdentityDbContext<ApplicationUser>
    {
        public TrainHoppersContext(DbContextOptions<TrainHoppersContext> options) : base(options) {}
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
