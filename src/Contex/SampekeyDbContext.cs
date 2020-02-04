using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sampekey.Model.Administration;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Configuration.Quid;
using Sampekey.Model.Identity;
using System;

namespace Sampekey.Contex
{
    public class SampekeyDbContex : IdentityDbContext<User,Role,string>
    {
        public SampekeyDbContex()
        { }

        public SampekeyDbContex(DbContextOptions<SampekeyDbContex> options) : base(options)
        { }


        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
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

            modelBuilder.Entity<User>().ToTable("T_USER");
            modelBuilder.Entity<Role>().ToTable("T_ROLE");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("T_USER_TOKEN");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("T_ROLE_CLAIM");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("T_USER_CLAIM");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("T_USER_LOGIN");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("T_USER_ROLE");

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

        }
    }
}
