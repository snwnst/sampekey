using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace sampekey.classes
{
    public class SampekeyDbContex : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public SampekeyDbContex()
        { }

        public SampekeyDbContex(DbContextOptions<SampekeyDbContex> options) : base(options)
        { }

        public virtual DbSet<IdentityUser> User { get; set; }
        public virtual DbSet<IdentityRole> Role { get; set; }
        public virtual DbSet<IdentityUserClaim<string>> UserClaim { get; set; }
        public virtual DbSet<IdentityUserLogin<string>> UserLogin { get; set; }
        public virtual DbSet<IdentityUserRole<string>> UserRole { get; set; }
        public virtual DbSet<IdentityUserToken<string>> UserToken { get; set; }
        public virtual DbSet<IdentityRoleClaim<string>> RoleClaim { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    Environment.GetEnvironmentVariable(
                        "PSQLS_SAMPEKEY"
                    )
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("USER");
            modelBuilder.Entity<IdentityRole>().ToTable("ROLE");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("USER_CLAIM");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("USER_LOGIN");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("USER_ROLE");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("USER_TOKEN");

        }
    }
}
