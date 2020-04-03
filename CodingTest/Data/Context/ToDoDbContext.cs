using CodingTest.Domain.Models;
using CodingTest.Domain.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Data.Context
{
    public class ToDoDbContext : DbContext
    {
        // initialize table to migrate
        public DbSet<Todo> TodoList { get; set; }

        // init db context
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        { }

        // make rules when migrate table
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Todo>().Property(c => c.Complete).HasDefaultValue(0);
            builder.Entity<Todo>().Property(c => c.Status).HasDefaultValue(EStatus.Pending);

        }
    }
}
