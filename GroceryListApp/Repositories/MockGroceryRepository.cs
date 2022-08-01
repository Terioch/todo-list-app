using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public class MockGroceryRepository : IGroceryRepository
    {
        private static readonly List<Grocery> _todoItems = new List<Grocery>();        

        public IEnumerable<Grocery> GetAll()
        {           
            return _todoItems;
        }

        public Grocery Get(int id)
        {
            return _todoItems.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Grocery item)
        {
            item.Id = new Random().Next();
            _todoItems.Add(item);
        }

        public void Update(Grocery item)
        {
            var originalItem = Get(item.Id);
            originalItem.Name = item.Name;
            originalItem.Price = item.Price;
            originalItem.Category = item.Category;
            originalItem.IsCompleted = item.IsCompleted;
        }

        public void Delete(Grocery item)
        {
            _todoItems.Remove(item);
        }

        public void DeleteRange(IEnumerable<Grocery> items)
        {
            _todoItems.RemoveRange(0, items.Count());
        }
    }
}
