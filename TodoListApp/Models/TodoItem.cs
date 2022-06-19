using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models
{
    public class TodoItem
    {
        /*private readonly int id;

        public int Id 
        { 
            get
            {
                return id;
            } 
            set
            {
                id = value;
            } 
        }*/

        public int Id { get; set; }

        [Required(ErrorMessage = "Text must not be empty")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Text must be at least 3 characters but no more than 10 characters")]
        public string Text { get; set; }

        public decimal Price { get; set; }

        public string PriceString
        {
            get
            {
                return $"${ Price }";
            }
        }

        public DateTimeOffset CreatedAt { get; set; }

        public bool IsCompleted { get; set; }
    }
}
