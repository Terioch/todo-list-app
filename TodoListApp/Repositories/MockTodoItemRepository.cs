using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public class MockTodoItemRepository : ITodoItemRepository
    {
        private static readonly List<TodoItem> _todoItems = new List<TodoItem>();        

        public IEnumerable<TodoItem> GetAll()
        {           
            return _todoItems;
        }

        public TodoItem Get(int id)
        {
            return _todoItems.FirstOrDefault(x => x.Id == id);
        }

        public void Add(TodoItem item)
        {
            item.Id = new Random().Next();
            _todoItems.Add(item);
        }

        public void Update(TodoItem item)
        {
            var originalItem = Get(item.Id);
            originalItem.Name = item.Name;
            originalItem.Price = item.Price;
            originalItem.IsCompleted = item.IsCompleted;
        }

        public void Delete(TodoItem item)
        {
            _todoItems.Remove(item);
        }

        public void DeleteRange(IEnumerable<TodoItem> items)
        {
            //_todoItems.RemoveRange(items);
            throw new NotImplementedException();
        }
    }
}
