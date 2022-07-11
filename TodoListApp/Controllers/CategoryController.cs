using Microsoft.AspNetCore.Mvc;
using System;
using TodoListApp.Models;
using TodoListApp.Repositories;

namespace TodoListApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _categoryStore;

        public CategoryController(IRepository<Category> categoryStore)
        {
            _categoryStore = categoryStore;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            var category = new Category
            {
                Name = model.Name,
                CreatedAt = DateTimeOffset.Now
            };

            _categoryStore.Add(category);

            return RedirectToAction("Index", "Home");
        }
    }
}
