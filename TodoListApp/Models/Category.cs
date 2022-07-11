using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        // Navigation property
        public List<Grocery> GroceryItems { get; set; }
    }
}
