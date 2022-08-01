using System.Collections.Generic;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        void Add(Category item);
        void Update(Category item);
        void Delete(Category item);
        void DeleteRange(IEnumerable<Category> items);
    }
}
