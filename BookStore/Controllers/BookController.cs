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
    [Authorize(Roles ="admin")]
    public class BookController : Controller
    {
        IConfiguration configuration;
        IBookService bookService;
        ICategoryService categoryService;
        IAuthorService authorService;
        VMBook vm;

        public BookController(IConfiguration _configuration,IBookService _bookService,ICategoryService _categoryService,IAuthorService _authorService)
        {
            configuration = _configuration;
            bookService = _bookService;
            categoryService = _categoryService;
            authorService = _authorService;
            vm = new VMBook();
        }
        public IActionResult Index()
        {
            vm.book = new Book();
            vm.categories = categoryService.LoadCategory();
            vm.authors = authorService.LoadAuthor();
            vm.books = bookService.LoadBook();
            return View("AddBook",vm);
        }
        public IActionResult Save(VMBook vm)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), configuration["FilePath"], vm.book.Image.FileName);
            vm.book.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.book.Path = "http://localhost/BookStore/img/" + vm.book.Image.FileName;

            bookService.Insert(vm.book);
            vm.books = bookService.LoadBook();
            vm.categories = categoryService.LoadCategory();
            vm.authors = authorService.LoadAuthor();
            return View("AddBook",vm);
        }
        public IActionResult Delete(int Id)
        {
            bookService.Delete(Id);
            vm.books = bookService.LoadBook();
            vm.categories = categoryService.LoadCategory();
            vm.authors = authorService.LoadAuthor();
            return View("AddBook",vm);
        }
        public IActionResult Edit(int Id)
        {
            vm.book = new Book();
            vm.book= bookService.Unchange(Id);
            //vm.categories = categoryService.LoadCategory();
            //vm.authors = authorService.LoadAuthor();
            //vm.books = bookService.LoadBook();
            return Json(vm.book);
        }
        public IActionResult Update(VMBook vm)
        {
            bookService.Update(vm.book);
            vm.book = new Book();
            vm.categories = categoryService.LoadCategory();
            vm.authors = authorService.LoadAuthor();
            vm.books = bookService.LoadBook();
            return View("AddBook",vm);
        }
    }
}
