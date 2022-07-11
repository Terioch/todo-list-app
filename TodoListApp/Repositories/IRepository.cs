using System.Collections.Generic;

namespace TodoListApp.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void DeleteRange(IEnumerable<T> items);
    }
}
