using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HordeWebSite.Data;
using Microsoft.AspNetCore.Identity;
using HordeWebSite.Models;
using HordeWebSite.Models.ViewModel;
using HordeWebSite.Utility;
using System.Security.Claims;

namespace HordeWebSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMailService _mailService;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountController(ApplicationDbContext db,
                                    IMailService mailService,
                                    UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mailService = mailService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ChangeRole()
        {
            GestionVM gvm = new GestionVM { };
            gvm.listItem = _userManager.Users.ToList();
            return View("Gestion", gvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(GestionVM model)
        {
            if (ModelState.IsValid && model.UserName != null)
            {

                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await _userManager.AddToRoleAsync(user, model.newRole);
                }
            }
            model.listItem = _userManager.Users.ToList();
            return View("Gestion",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> deleteRole(GestionVM model)
        {
            if (ModelState.IsValid && model.UserName != null && model.newRole != Helper.Admin)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await _userManager.RemoveFromRoleAsync(user, model.newRole);
                }
            }
            if (model.newRole == Helper.Admin)
            {
                ModelState.AddModelError("", "impossible de supprimer le rôle Admin");
            }
            model.listItem = _userManager.Users.ToList();
            return View("Gestion", model);
        }

        public async Task<IActionResult> getRoleUser(string Name)
        {
            var user = await _userManager.FindByNameAsync(Name);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                userRoles.Remove("Admin");
                return PartialView("_partialListRolesUser", userRoles);
            }
            return PartialView("_partialListRolesUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Helper.Invite);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                       "ConfirmEmail", "Account",
                       new { userId = user.Id, code = code },
                       protocol: "https");

                    MailRequest mail = new MailRequest(
                        user.Email,
                       "Confirm your account",
                       "Please confirm your account by clicking this link: <a href=\""
                                                       + callbackUrl + "\">link</a>");
                    await _mailService.SendEmailAsync(mail);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Combinaison Email et Mot de passe invalide");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logoff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user,false);
                return View("ConfirmEmail");
            }
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return View();
        }
    }
}
