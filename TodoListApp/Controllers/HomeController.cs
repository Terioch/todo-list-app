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
        private readonly List<TodoItem> _todoItems = new List<TodoItem>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var item = new TodoItem
            {
                Id = 1,
                Text = "Test item",
                CreatedAt = DateTimeOffset.Now,
                IsCompleted = false,
            };
            _todoItems.Add(item);
            return View("Index", _todoItems);
        }

        public IActionResult Create()
        {
            return View("Create"); // Create is inferred by the method name
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
