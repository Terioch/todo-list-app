using System;
using System.Collections.Generic;
using TodoListApp.Contexts;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public class TodoItemRepository
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
            throw new NotImplementedException();
        }

        public void Add(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
