using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.Contexts;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public class GroceryRepository : IRepository<Grocery>
    {
        private readonly ApplicationDbContext _db;

        public GroceryRepository(ApplicationDbContext db)
        {
            _db = db;           
        }

        public IEnumerable<Grocery> GetAll()
        {
            return _db.Groceries;
        }

        public Grocery Get(int id)
        {
            return _db.Groceries.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Grocery item)
        {
            _db.Groceries.Add(item);
            _db.SaveChanges();
        }

        public void Update(Grocery item)
        {
            var originalItem = Get(item.Id);
            originalItem.CategoryId = item.CategoryId;
            originalItem.Name = item.Name;
            originalItem.Price = item.Price;            
            originalItem.IsCompleted = item.IsCompleted;
            _db.SaveChanges();
        }

        public void Delete(Grocery item)
        {
            _db.Groceries.Remove(item);
            _db.SaveChanges();
        }

        public void DeleteRange(IEnumerable<Grocery> items)
        {
            _db.Groceries.RemoveRange(items);
            _db.SaveChanges();
        }
    }
}
