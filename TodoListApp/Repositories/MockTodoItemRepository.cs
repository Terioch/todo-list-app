using System;
using System.Collections.Generic;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public class MockTodoItemRepository
    {
        private static readonly List<TodoItem> _todoItems = new List<TodoItem>();

        public List<TodoItem> GetAll()
        {
            return _todoItems;
        }

        public void Add(TodoItem item)
        {
            _todoItems.Add(item);
        }

        public void Update(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
