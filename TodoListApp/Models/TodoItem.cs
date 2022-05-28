using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]        
        public string Text { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public bool IsCompleted { get; set; }
    }
}
