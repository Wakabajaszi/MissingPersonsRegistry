using DissapearPersonsRegistry.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissingPersonsRegistry.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DissapearPersonsRegistry.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext dbContext;
        public RoleManager<IdentityRole> roleManager;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext dbContext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index() 
        {
            await CreateRoles();

            var users = dbContext.Users;
            var usersParse = UserParserAll(users);

            return View(usersParse);
            
        }
        public async Task CreateRoles()
        {
            var isRoleExists = await roleManager.FindByNameAsync("Admin");
            if (isRoleExists == null)
            {
                IdentityRole adminRole = new IdentityRole { Name = "Admin" };
                IdentityRole guestRole = new IdentityRole { Name = "Guest" };

                IdentityResult resultAdmin = await roleManager.CreateAsync(adminRole);
                IdentityResult resultGuest = await roleManager.CreateAsync(guestRole);

                IdentityUser user1 = await userManager.FindByIdAsync("b95768d3-ec6a-4238-894b-08054ee8fc51");
                resultAdmin = await userManager.AddToRoleAsync(user1, "Admin");

            }
        }

        private List<User> UserParserAll(IEnumerable<IdentityUser> userIdentity)
        {
            var allUsers = new List<User>();
            foreach (var item in userIdentity)
            {
                var getRoleId = dbContext.UserRoles.First(p => p.UserId == item.Id);
                var getRole = dbContext.Roles.FirstOrDefault(p => p.Id == getRoleId.RoleId);
                var user = new User()
                {
                    Id = item.Id,
                    Email = item.Email,
                    RoleName = getRole.Name
                };
                allUsers.Add(user);
            }
            
            return allUsers;
        }
        private User UserParser(IdentityUser userIdentity)
        {
            var getRoleId = dbContext.UserRoles.First(p => p.UserId == userIdentity.Id);
            var getRoleName = dbContext.Roles.FirstOrDefault(p => p.Id == getRoleId.RoleId);
            var user = new User()
            {
                Id = userIdentity.Id,
                Email = userIdentity.Email,
                RoleName = getRoleName.Name
            };
            return user;
        }
    }
}
