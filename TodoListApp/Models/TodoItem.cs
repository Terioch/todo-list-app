using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters but no more than 10 characters")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }        

        public DateTimeOffset CreatedAt { get; set; }

        public bool IsCompleted { get; set; }

        [NotMapped]
        public string PriceString
        {
            get
            {
                return $"${ Price }";
            }
        }
    }
}
