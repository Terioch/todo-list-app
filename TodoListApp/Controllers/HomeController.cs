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
        private readonly IGroceryRepository _todoItemStore;

        public HomeController(ILogger<HomeController> logger, IGroceryRepository todoItemStore)
        {
            _logger = logger;
            _todoItemStore = todoItemStore;
        }

        public IActionResult Index()
        {  
            return View(_todoItemStore.GetAll());
        }

        public IActionResult Search(string searchTerm)
        {
            var items = _todoItemStore.GetAll();

            if (searchTerm == null)
            {               
                return View("Index", items);            
            }

            var filteredItems = items.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));

            return View("Index", filteredItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }    
        
        [HttpPost]
        public IActionResult Create(Grocery model)
        {
            var item = new Grocery
            {                
                Name = model.Name,
                Price = model.Price,  
                Category = model.Category,
                CreatedAt = DateTimeOffset.Now,
                IsCompleted = false
            };
            
            _todoItemStore.Add(item);                       

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {                        
            var item = _todoItemStore.Get(id);

            if (item == null)
            {
                ViewBag.ErrorMessage = $"An item with the id { id } was not found";
                return View("NotFound");
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Grocery model)
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
                
        public IActionResult DeleteAll()
        {
            var items = _todoItemStore.GetAll();            

            /*foreach (var item in items)
            {
                _todoItemStore.Delete(item);
            }*/

            _todoItemStore.DeleteRange(items);

            return RedirectToAction("Index");
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
