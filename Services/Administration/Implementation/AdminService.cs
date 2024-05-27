using Address_Book.Services.Administration.Interface;
using Address_Book.Services.DTO.ReadOnly;
using Address_Book.Services.DTO.WriteOnly;
using Address_Book.Services.Helpers;
using Address_Book.Services.Models;
using Microsoft.AspNetCore.Identity;

namespace Address_Book.Services.Administration.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<AddressBookUser> userManager;
        private readonly RoleManager<IdentityRole> roleManger;
        private readonly SignInManager<AddressBookUser> signInManager;

        public AdminService(UserManager<AddressBookUser> userManager,
                            RoleManager<IdentityRole> roleManger,
                            SignInManager<AddressBookUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManger = roleManger;
            this.signInManager = signInManager;
        }

        public async Task<List<UsersInRoleDTO>> GetUsersInRoles(string rolename)
        {
            IList<AddressBookUser> users = await userManager.GetUsersInRoleAsync(rolename);

            if (!users.Any()) return null;

            List<UsersInRoleDTO> usersInRoles = users.Select(user => new UsersInRoleDTO()
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            }).ToList();

            return usersInRoles;
        }

        public Result GetAllRoles()
        {
            try
            {
                List<IdentityRole> roles = roleManger.Roles.ToList();

                List<RoleDTOw> rolesWithUsers = roles.Select(role => new RoleDTOw()
                {
                    Id = role.Id,
                    Name = role.Name,
                    UsersInRoles = GetUsersInRoles(role.Name).GetAwaiter().GetResult()
                }).ToList();

                return Result.Success(rolesWithUsers);
            }
            catch { throw; }
        }

        public async Task<Result> CreateRole(string rolename)
        {
            try
            {
                if (string.IsNullOrEmpty(rolename)) return Result.Failure("Role name cannot be empty.");

                var RoleExist = await roleManger.FindByNameAsync(rolename);

                if (RoleExist != null) return Result.Failure("Role already exists.");

                IdentityRole role = new() { Name = rolename };

                var result = await roleManger.CreateAsync(role);

                if (result.Succeeded) return Result.Success("Role Created Successfully.");

                return Result.Failure("Failed to create role.");
            }
            catch { throw; }
        }

        public async Task<Result> UpdateRole(string roleId, string rolename)
        {
            try
            {
                if (string.IsNullOrEmpty(rolename)) return Result.Failure("Role name cannot be empty.");

                var roleExist = await roleManger.FindByIdAsync(roleId);

                if (roleExist == null) return Result.Failure("Role not found.");

                roleExist.Name = rolename;

                var result = await roleManger.UpdateAsync(roleExist);

                if (result.Succeeded) return Result.Success("Role Updated Successfully.");

                return Result.Failure("Failed To Update Role.");
            }
            catch { throw; }
        }

        public async Task<Result> DeleteRole(string rolename)
        {
            try
            {
                if (string.IsNullOrEmpty(rolename)) return Result.Failure("Role name cannot be empty.");

                var roleExist = await roleManger.FindByNameAsync(rolename);

                if (roleExist == null) return Result.Failure("Role not found.");

                var result = await roleManger.DeleteAsync(roleExist);

                if (result.Succeeded) return Result.Success("Role Deleted Successfully.");

                return Result.Failure("Failed To Delete Role.");
            }
            catch { throw; }
        }

        #region IS EMAIL IN USE
        public async Task<bool> IsEmailInUse(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);

                if (user == null) return true;

                return false;
            }
            catch { throw; }
        }
        #endregion

        public async Task<Result> Register(string firstname, string lastname, string email, string password)
        {
            try
            {
                AddressBookUser user = new() { FirstName = firstname, LastName = lastname, UserName = email, Email = email };
                var result = await userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        string errorMessage = error.Description;
                        return Result.Failure(errorMessage);
                    }
                }

                await signInManager.SignInAsync(user, false);
                return Result.Success("User Registered Successfully.");
            }
            catch
            {
                throw;
            }
        }

        public async Task<Result> Login(string email, string password, bool rememberMe)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(email, password, rememberMe, false);

                if (!result.Succeeded) return Result.Failure("Invalid Login Attempt.");

                return Result.Success("User Logged In.");
            }
            catch { throw; }
        }

        public async Task Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch { throw; }
        }
    }
}
