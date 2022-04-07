using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Malie.Idp.Data
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public IdentityDbContext() { }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasIndex(e => e.Subject)
                       .IsUnique();
                builder.HasIndex(e => e.UserName)
                       .IsUnique();

                builder.HasData(new[]
                {
                    new User
                    {
                        Id = new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"),
                        Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                        UserName = "alisa",
                        Password = "Ali$@",
                        Active = true,
                    },
                    new User
                    {
                        Id = new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"),
                        Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                        UserName = "kadija",
                        Password = "K@dij@",
                        Active = true
                    }
                });
            });

            modelBuilder.Entity<UserClaim>(builder =>
            {
                builder.HasData(new[]
                {
                    new UserClaim 
                    {
                        Id = Guid.NewGuid(),
                        UserId = new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"),
                        Type = "given_name",
                        Value = "Alisa"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"),
                        Type = "family_name",
                        Value = "Pussah"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"),
                        Type = "address",
                        Value = "2220 S 66th Street, Norwood, Essignton EX 11001"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"),
                        Type = "role",
                        Value = "FreeUser"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"),
                        Type = "subscriptionlevel",
                        Value = "FreeUser"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("ad23ce84-d9f8-4135-ab35-a8d03a831819"),
                        Type = "country",
                        Value = "us"
                    },
                    new UserClaim
                    {
                        Id = Guid.NewGuid(),
                        UserId = new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"),
                        Type = "given_name",
                        Value = "Kadija"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"),
                        Type = "family_name",
                        Value = "Pussah"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"),
                        Type = "address",
                        Value = "2220 S 66th Street, Norwood, Essignton EX 11001"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"),
                        Type = "role",
                        Value = "PayingUser"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"),
                        Type = "subscriptionlevel",
                        Value = "PayingUser"
                    },
                    new UserClaim
                    {
                        Id= Guid.NewGuid(),
                        UserId = new Guid("0adf529e-92eb-47bd-ba32-a6dc55589fc0"),
                        Type = "country",
                        Value = "be"
                    }
                });
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var updatedEntries = ChangeTracker.Entries()
                                              .Where(e => e.State == EntityState.Modified)
                                              .OfType<IConcurrencyAware>();

            foreach (var entry in updatedEntries)
            {
                entry.ConcurrencyStamp = $"{Guid.NewGuid()}";
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
