﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoListApp.Models;

namespace TodoListApp.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Grocery> Groceries { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
