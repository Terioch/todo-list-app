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
            return View(_categoryStore.GetAll());
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
                CreatedAt = DateTimeOffset.UtcNow
            };

            _categoryStore.Add(category);

            return RedirectToAction("Index", "Category");
        }
    }
}
