using System.Collections.Generic;
using TodoListApp.Contexts;
using TodoListApp.Models;

namespace TodoListApp.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Category item)
        {
            _db.Categories.Add(item);
            _db.SaveChanges();
        }

        public void Delete(Category item)
        {
            _db.Categories.Remove(item);
        }

        public void DeleteRange(IEnumerable<Category> items)
        {
            throw new System.NotImplementedException();
        }

        public Category Get(int id)
        {
            return _db.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories;
        }

        public void Update(Category item)
        {
            throw new System.NotImplementedException();
        }
    }
}
