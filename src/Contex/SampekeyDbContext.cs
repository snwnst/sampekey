using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sampekey.Model;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Contex
{
    public class SampekeyDbContex : IdentityDbContext<User, Role, string>
    {
        public SampekeyDbContex()
        { }

        public SampekeyDbContex(DbContextOptions<SampekeyDbContex> options) : base(options)
        { }


        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleClaim> RoleClaim { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SQL_SAMPEKEY"));
             
            //optionsBuilder.UseSqlServer("Server=cnsfsqlbisie.cnsf.gob.mx;Database=SAMPEKEY;User Id=ETL_Adm;Password=ETLAdmin123#;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Role>().ToTable("T_ROLE");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("T_ROLE_CLAIM");
            modelBuilder.Entity<User>().ToTable("T_USER");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("T_USER_CLAIM");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("T_USER_LOGIN");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("T_USER_ROLE");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("T_USER_TOKEN");

        }
    }
}
