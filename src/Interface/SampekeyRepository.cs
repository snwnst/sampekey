using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sampekey.Contex;
using Sampekey.Model.Administration;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Configuration.Quid;
using Sampekey.Model.Identity;

namespace Sampekey.Interface
{
    public interface SampekeyRepository
    {
        Task<IEnumerable<UserRole>> GetAllUserRoles();
        Task<IEnumerable<UserRole>> FindUserRolesByUserId(string value);
        Task<IEnumerable<UserRole>> FindUserRolesByRoleId(string value);
        Task<UserRole> AddUserRole(UserRole value);
        Task<bool> DeleteUserRole(UserRole value);

        Task<IEnumerable<User>> GetAllUsers();
        Task<User> FindUserById(string value);
        Task<User> FindUserByUsername(string value);
        Task<User> AddUser(User value);
        Task<User> UpdateUser(User value);
        Task<bool> DeleteUser(User value);

        Task<IEnumerable<ProjectModule>> GetAllProjectModules();
        Task<ProjectModule> FindProjectModuleById(string value);
        Task<ProjectModule> AddProjectModule(ProjectModule value);
        Task<ProjectModule> UpdateProjectModule(ProjectModule value);
        Task<bool> DeleteProjectModule(ProjectModule value);

        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> FindProjectById(string value);
        Task<Project> AddProject(Project value);
        Task<Project> UpdateProject(Project value);
        Task<bool> DeleteProject(Project value);

        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> FindRoleById(string value);
        Task<Role> AddRole(Role value);
        Task<Role> UpdateRole(Role value);
        Task<bool> DeleteRole(Role value);

        Task<IEnumerable<Permission>> GetAllPermissions();
        Task<Permission> FindPermissionById(string value);
        Task<Permission> AddPermission(Permission value);
        Task<Permission> UpdatePermission(Permission value);
        Task<bool> DeletePermission(Permission value);

        Task<IEnumerable<Module>> GetAllModules();
        Task<Module> FindModuleById(string value);
        Task<Module> AddModule(Module value);
        Task<Module> UpdateModule(Module value);
        Task<bool> DeleteModule(Module value);

        Task<IEnumerable<EnviromentProjectRolePermission>> GetAllEnviromentProjectRolePermissions();
        Task<EnviromentProjectRolePermission> FindEnviromentProjectRolePermissionById(string value);
        Task<EnviromentProjectRolePermission> AddEnviromentProjectRolePermission(EnviromentProjectRolePermission value);
        Task<EnviromentProjectRolePermission> UpdateEnviromentProjectRolePermission(EnviromentProjectRolePermission value);
        Task<bool> DeleteEnviromentProjectRolePermission(EnviromentProjectRolePermission value);

        Task<IEnumerable<Enviroment>> GetAllEnviroments();
        Task<Enviroment> FindEnviromentById(string value);
        Task<Enviroment> AddEnviroment(Enviroment value);
        Task<Enviroment> UpdateEnviroment(Enviroment value);
        Task<bool> DeleteEnviroment(Enviroment value);

        Task<Boolean> Login(SampekeyUserAccountRequest userAccountRequest);
        Task UpdateForcePaswordAsync(SampekeyUserAccountRequest userAccountRequest);
        HashSet<string> GetUsersWithActiveDirectory(SampekeyUserAccountRequest userAccountRequest);
        Task<IdentityResult> CreateUser(SampekeyUserAccountRequest userAccountRequest);
        Task<IdentityResult> AddDefaultRoleToUser(User user);


    }
}
