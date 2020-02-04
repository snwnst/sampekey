using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sampekey.Model.Administration;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Configuration.Quid;
using Sampekey.Model.Identity;
using System;

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
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Enviroment> Enviroment { get; set; }
        public virtual DbSet<EnviromentProjectRolePermission> EnviromentProjectRolePermission { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ProjectModule> ProjectModule { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("MSQL_SAMPEKEY"));
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
            modelBuilder.Entity<RoleClaim>();
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<Module>();
            modelBuilder.Entity<ProjectModule>();
            modelBuilder.Entity<Enviroment>();
            modelBuilder.Entity<EnviromentProjectRolePermission>();
            modelBuilder.Entity<Permission>();

            modelBuilder.Entity<ProjectModule>(entity =>
            {
                entity.HasKey(c => new { c.Id, c.ProjectId, c.ModuleId });
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectModules)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.ProjectModules)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EnviromentProjectRolePermission>(entity =>
            {
                entity.HasKey(c => new { c.Id, c.EnviromentId, c.ProjectId, c.RoleId, c.PermissionId });

                entity.HasOne(d => d.Enviroment)
                    .WithMany(p => p.EnviromentProjectRolePermissions)
                    .HasForeignKey(d => d.EnviromentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EnviromentProjectRolePermissions)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EnviromentProjectRolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.EnviromentProjectRolePermissions)
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



        }
    }
}
