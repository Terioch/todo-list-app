using System.Collections.Generic;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem Get(int id);
        void Add(TodoItem item);
        void Update(TodoItem item);
        void Delete(TodoItem item);
    }
}
