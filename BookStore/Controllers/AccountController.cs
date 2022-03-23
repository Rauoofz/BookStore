using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;
        VMSignUp signUp;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
            signUp = new VMSignUp();
        }
        public IActionResult Index()
        {
            signUp.liRole = accountService.GetRole();
            return View("SignUp",signUp);
        }
        public async Task<IActionResult> SignUp(VMSignUp vm)
        {
            vm.liRole = accountService.GetRole();
            var result= await accountService.Create(vm.signUp);
            if (result.Succeeded)
            {
                return View("SignUp", vm);
            }else
            {
                ViewData["Error"] = "Username Is Token";
                return View("SignUp", vm);
            }
        }

        public IActionResult Index1()
        {
            return View("SignIn");
        }
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result= await accountService.SignIn(model);

            if(result.Succeeded)
            {
                return RedirectToAction("Index","Book");
            }
            else
            {
                ViewData["error"] = "Invalid Username OR Password";
                return View("SignIn");
            }
            
        }

        public IActionResult Role()
        {
            return View("AddRole");
        }

        public async Task<IActionResult> AddRole(RoleModel model)
        {
            var result= await accountService.AddRole(model);
            return View("AddRole");
        }
        public async Task<IActionResult> LogOut()
        {
            await accountService.Logout();
            signUp.liRole = accountService.GetRole();
            return View("SignUp",signUp);
        }

        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}
