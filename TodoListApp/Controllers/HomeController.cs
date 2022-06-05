using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Models;
using TodoListApp.Repositories;

namespace TodoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private static readonly List<TodoItem> _todoItems = new List<TodoItem>();
        private readonly MockTodoItemRepository _todoItemStore;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _todoItemStore = new MockTodoItemRepository(); // Create new instance of item data access class
        }

        public IActionResult Index()
        {  
            return View(_todoItemStore.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }    
        
        [HttpPost]
        public IActionResult Create(TodoItem model)
        {
            var item = new TodoItem
            {
                Id = new Random().Next(),
                Text = model.Text,
                CreatedAt = DateTimeOffset.Now,
                IsCompleted = false
            };
            
            _todoItemStore.Add(item);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var items = _todoItemStore.GetAll();

            var item = items.FirstOrDefault(x => x.Id == id); // Get first item with a matching id

            if (item == null)
            {
                ViewBag.ErrorMessage = $"An item with the id { id } was not found";
                return View("NotFound");
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem model)
        {            
            var items = _todoItemStore.GetAll(); // Fetch items from mock repository (data access layer)

            var originalItem = items.FirstOrDefault(x => x.Id == model.Id);

            var newItem = new TodoItem
            {
                Id = originalItem.Id,
                Text = model.Text,
                CreatedAt = originalItem.CreatedAt,
                IsCompleted = model.IsCompleted
            };

            int index = items.IndexOf(originalItem); // Get the index of this item within the collection

            items[index] = newItem; // Access this item by its index and assign our new item

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var items = _todoItemStore.GetAll();

            var item = items.FirstOrDefault(x => x.Id == id);

            items.Remove(item);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
