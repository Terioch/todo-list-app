using System;
using System.Collections.Generic;

namespace TodoListApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        // Navigation property
        public List<Grocery> GroceryItems { get; set; }
    }
}
