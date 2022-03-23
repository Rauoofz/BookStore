using BookStore.data;
using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class AuthorController : Controller
    {
        IAuthorService authorService;
        INationalityService nationalityService;
        IConfiguration configuration;
        VMAuthor vm;

        public AuthorController(IAuthorService _authorService, INationalityService _nationalityService, IConfiguration _configuration)
        {
            authorService = _authorService;
            nationalityService = _nationalityService;
            configuration = _configuration;
            vm = new VMAuthor();
        }
        public IActionResult Index()
        {
            vm.Auth = new Author();
            vm.nationalities = nationalityService.LoadNationality();
            vm.authors = authorService.LoadAuthor();
            return View("AddAuthors", vm);
        }

        public IActionResult Save(VMAuthor vm)
        {
            vm.nationalities = nationalityService.LoadNationality();
            string path = Path.Combine(Directory.GetCurrentDirectory(), configuration["FilePath"], vm.Auth.Image.FileName);
            vm.Auth.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.Auth.Path = "http://localhost/BookStore/img/" + vm.Auth.Image.FileName;
            authorService.Insert(vm.Auth);
            vm.authors = authorService.LoadAuthor();


            return View("AddAuthors", vm);
        }
        public IActionResult Delete(int Id)
        {
            authorService.Delete(Id);
            vm.Auth = new Author();
            vm.nationalities = nationalityService.LoadNationality();
            vm.authors = authorService.LoadAuthor();
            return View("AddAuthors", vm);
        }
        public IActionResult Edit(int Id)
        {
            vm.Auth = new Author();
            //vm.nationalities = nationalityService.LoadNationality();
            //vm.authors = authorService.LoadAuthor();
            vm.Auth = authorService.Unchange(Id);
            return Json(vm.Auth);
        }
        public IActionResult Update(VMAuthor vm)
        {
            authorService.Update(vm.Auth);
            vm.Auth = new Author();
            vm.nationalities = nationalityService.LoadNationality();
            vm.authors = authorService.LoadAuthor();
            return View("AddAuthors", vm);
        }
    }
}

