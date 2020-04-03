using CodingTest.Data.Context;
using CodingTest.Domain.Models;
using CodingTest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Data.Repositories
{
    public class TodoRepository : BaseRepository, ITodoRepository
    {
        // initial context Todo
        public TodoRepository(ToDoDbContext context) : base(context)
        {
        }

        // process show All data also can show specific data
        public async Task<IEnumerable<Todo>> ListAsync(int ID)
        {
            if (ID == 0)
                return await _context.TodoList
                .AsNoTracking()
                .ToListAsync();

            var result = await _context.TodoList
                .AsNoTracking()
                .Where(data => data.Id == ID)
                .ToListAsync();

            return result;
        }

        // process save data
        public async Task AddAsync(Todo todo)
        {
            await _context.TodoList.Add(todo).Context.SaveChangesAsync();
        }

        // search data on data available or not
        public async Task<Todo> FindByIdAsync(int id)
        {
            return await _context.TodoList.FindAsync(id);
        }

        // process update all data, mark as done and set todo will complete
        public void Update(Todo todo)
        {
            _context.TodoList.Update(todo).Context.SaveChanges();
        }

        // delete data todolist
        public void Remove(Todo todo)
        {
            _context.TodoList.Remove(todo).Context.SaveChanges();
        }
    }
}
