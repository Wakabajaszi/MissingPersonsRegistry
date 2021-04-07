using DissapearPersonsRegistry.Models;
using DissapearPersonsRegistry.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissingPersonsRegistry.Data;


namespace DissapearPersonsRegistry.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController( IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Index() 
        {
            var users = accountService.Index();
            return View(users); 
        }
        public IActionResult Edit(string id) 
        {
            var user = accountService.GetUser(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user) 
        {
            accountService.Edit(user);
            return RedirectToAction("Index", "Account");
        }
        public IActionResult Delete(string id) 
        {
            var user = accountService.GetUser(id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(string id)
        {
            accountService.Delete(id);
            return RedirectToAction("Index","Account");
        }
    }
}
