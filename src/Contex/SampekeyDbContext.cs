using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Sampekey.Model.Administration;
using Sampekey.Model.Identity;
using Sampekey.Model.Configuration.Module;

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
        public virtual DbSet<Castle> Castle { get; set; }
        public virtual DbSet<Kingdom> Kingdom { get; set; }
        public virtual DbSet<KingdomCastleRolePermission> KingdomCastleRolePermission { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SQL_SAMPEKEY"));
            optionsBuilder.UseSqlServer("Server=cnsfsqlbisie.cnsf.gob.mx;Database=SAMPEKEY;User Id=ETL_Adm;Password=ETLAdmin123#;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>();
            modelBuilder.Entity<RoleClaim>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<UserClaim>();
            modelBuilder.Entity<UserLogin>();
            modelBuilder.Entity<UserRole>();
            modelBuilder.Entity<UserToken>();
            modelBuilder.Entity<Castle>();
            modelBuilder.Entity<Kingdom>();
            modelBuilder.Entity<KingdomCastleRolePermission>();
            modelBuilder.Entity<Permission>();

            modelBuilder.Entity<KingdomCastleRolePermission>(entity =>
            {
                entity.HasKey(c => new { c.KingdomId, c.CastleId, c.RoleId, c.PermissionId });

                entity.HasOne(d => d.Kingdom)
                    .WithMany(p => p.KingdomCastleRolePermissions)
                    .HasForeignKey(d => d.KingdomId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Castle)
                    .WithMany(p => p.KingdomCastleRolePermissions)
                    .HasForeignKey(d => d.CastleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.KingdomCastleRolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.KingdomCastleRolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Role)
                   .WithMany(p => p.UserRoles)
                   .HasForeignKey(d => d.RoleId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Permission>();

        }
    }
}
