using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly List<TodoItem> _todoItems = new List<TodoItem>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {            
            return View(_todoItems);
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

            _todoItems.Add(item);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _todoItems.FirstOrDefault(x => x.Id == id); // Get first item with a matching id

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem model)
        {
            // Alternative way to get original item with matching id using a for loop
            TodoItem originalItem = new TodoItem();

            for (int i = 0; i < _todoItems.Count(); i++)
            {
                if (_todoItems[i].Id == model.Id)
                {
                    originalItem = _todoItems[i];
                }
            }

            //var originalItem = _todoItems.FirstOrDefault(x => x.Id == model.Id);

            var newItem = new TodoItem
            {
                Id = originalItem.Id,
                Text = model.Text,
                CreatedAt = originalItem.CreatedAt,
                IsCompleted = model.IsCompleted
            };

            int index = _todoItems.IndexOf(originalItem); // Get the index of this item within the collection

            _todoItems[index] = newItem; // Access this item via indexing and assign our new item

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
