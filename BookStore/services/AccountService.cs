using BookStore.data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class AccountService: IAccountService
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager,RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public async Task<IdentityResult> Create(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = model.Name;
            user.UserName = model.UserName;
            user.Email = model.Email;

            var result= await userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
               IdentityRole role= await roleManager.FindByIdAsync(model.Role_Id);
               result= await userManager.AddToRoleAsync(user, role.Name);
            }
            return result;
        }

        public async Task<SignInResult> SignIn(SignInModel model)
        {
            var result= await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RemeberMe, false);
            return result;
        }

        public async Task<IdentityResult> AddRole(RoleModel model)
        {
            IdentityRole role = new IdentityRole();
            role.Name = model.Name;
            var result= await roleManager.CreateAsync(role);
            return result;
        }

        public List<IdentityRole> GetRole()
        {

            List<IdentityRole> roles = roleManager.Roles.ToList();
            return roles;
            
        }
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }


    }
}
