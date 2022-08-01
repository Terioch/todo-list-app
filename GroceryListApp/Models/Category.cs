using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [NotMapped]
        public string CreatedAtString
        {
            get
            {
                return CreatedAt.ToString("dd/MM/yyyy");
            }
        }

        // Navigation property
        public List<Grocery> GroceryItems { get; set; }
    }
}
