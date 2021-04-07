﻿using DissapearPersonsRegistry.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissingPersonsRegistry.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DissapearPersonsRegistry.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public AccountController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index() 
        {
           
            var users = dbContext.Users.ToList();
            var usersParse = UserParserAll(users);

            return View(usersParse);
            
        }
        public IActionResult Edit(string id) 
        {
            var user = dbContext.Users.First(p => p.Id == id.ToString());
            if(user == null) 
            {
                throw new Exception("Nie znaleziono użytkownika");
            }
            var userParse = UserParser(user);
            return View(userParse);
        }
        [HttpPost]
        public IActionResult Edit(User user) 
        {
            IdentityUserParser(user);
            return RedirectToAction("Index", "Account");
        }
        public IActionResult Delete(string id) 
        {
            var user = dbContext.Users.FirstOrDefault(p => p.Id == id);
            var userParse = UserParser(user);
            return View(userParse);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(string id)
        {
            var user = dbContext.Users.FirstOrDefault(p => p.Id == id);
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Account");
        }


       

        private List<User> UserParserAll(IEnumerable<IdentityUser> userIdentity)
        {
            var allUsers = new List<User>();
            foreach (var item in userIdentity)
            {
                var getRoleId = dbContext.UserRoles.FirstOrDefault(p => p.UserId == item.Id);
                var getRole = dbContext.Roles.FirstOrDefault(p => p.Id == getRoleId.RoleId);
                var user = new User()
                {
                    Id = item.Id,
                    UserName = item.UserName,
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
                UserName = userIdentity.UserName,
                Email = userIdentity.Email,
                RoleName = getRoleName.Name
            };
            return user;
        }
        private void IdentityUserParser(User user)
        {


            var getUserIdentity = dbContext.Users.FirstOrDefault(p => p.Id == user.Id);

            getUserIdentity.UserName = user.UserName;
            getUserIdentity.Email = user.Email;

            var userRole = dbContext.UserRoles.FirstOrDefault(p => p.UserId == user.Id);
            var role = dbContext.Roles.FirstOrDefault(p => p.Name == user.RoleName);

            dbContext.Remove(userRole);
            dbContext.SaveChanges();

            userRole.RoleId = role.Id;
            dbContext.UserRoles.Add(userRole);
            dbContext.SaveChanges();

        }
    }
}
