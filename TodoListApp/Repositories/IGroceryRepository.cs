using System.Collections.Generic;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public interface IGroceryRepository
    {
        IEnumerable<Grocery> GetAll();
        Grocery Get(int id);
        void Add(Grocery item);
        void Update(Grocery item);
        void Delete(Grocery item);
        void DeleteRange(IEnumerable<Grocery> items);
    }
}
