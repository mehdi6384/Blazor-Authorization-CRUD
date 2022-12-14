using Duende.IdentityServer.EntityFramework.Options;
using LiveTVAdmin.Shared;
using LiveTVShow.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LiveTVShow.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Show>();
            builder.Entity<Episode>();
        }
        public DbSet<LiveTVAdmin.Shared.Episode> Episode { get; set; }
        public DbSet<LiveTVAdmin.Shared.Show> Show { get; set; }
    }
}