using BookStore.data;
using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        BookContext context;
        VMCategory vm;
        public CategoryController(ICategoryService _categoryService, BookContext _context)
        {
            categoryService = _categoryService;
            context = _context;
            vm = new VMCategory();
        }
        public IActionResult Index()
        {
            vm.licate = categoryService.LoadCategory();
            vm.cate = new Category();
            return View("AddCategory", vm);
        }
        public IActionResult Save(VMCategory vm)
        {
            categoryService.Insert(vm.cate);
            vm.licate = categoryService.LoadCategory();
            return View("AddCategory", vm);
        }

        public IActionResult Delete(int Id)
        {

            categoryService.Delete(Id);
            vm.licate = categoryService.LoadCategory();
            return View("AddCategory", vm);
        }

        public IActionResult Edit(int Id)
        {
            vm.licate = categoryService.LoadCategory();
            vm.cate = categoryService.Unchange(Id);
            return Json(vm.cate);
        }
        public IActionResult Update(VMCategory vm)
        {
            categoryService.Update(vm.cate);
            vm.licate = categoryService.LoadCategory();
            vm.cate = new Category();
            return View("AddCategory", vm);
        }

    }
}

