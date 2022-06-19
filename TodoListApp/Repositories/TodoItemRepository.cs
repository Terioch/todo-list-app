using System;
using System.Collections.Generic;
using System.Linq;
using TodoListApp.Contexts;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _db;

        public TodoItemRepository(ApplicationDbContext db)
        {
            _db = db;           
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _db.TodoItems;
        }

        public TodoItem Get(int id)
        {
            return _db.TodoItems.FirstOrDefault(x => x.Id == id);
        }

        public void Add(TodoItem item)
        {
            _db.TodoItems.Add(item);
            _db.SaveChanges();
        }

        public void Update(TodoItem item)
        {
            var originalItem = Get(item.Id);
            originalItem.Text = item.Text;
            originalItem.IsCompleted = item.IsCompleted;
            _db.SaveChanges();
        }

        public void Delete(TodoItem item)
        {
            _db.TodoItems.Remove(item);
            _db.SaveChanges();
        }        
    }
}
