using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Contexts;
using TodoListApp.Models;
using TodoListApp.Repositories;

namespace TodoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MockTodoItemRepository _todoItemStore;        


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _todoItemStore = new MockTodoItemRepository();
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

            var item = items.FirstOrDefault(x => x.Id == id);

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
            _todoItemStore.Update(model);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var item = _todoItemStore.Get(id);

            if (item == null)
            {
                ViewBag.ErrorMessage = $"An item with the id { id } was not found";
                return View("NotFound");
            }

            _todoItemStore.Delete(item);

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
