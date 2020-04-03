using CodingTest.Domain.Models;
using CodingTest.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Domain.Services
{
    public interface ITodoService
    {
        // process show All data also can show specific data
        Task<IEnumerable<Todo>> ListAsync(int ID);
        // process save data
        Task<TodoResponse> SaveAsync(Todo todo);
        // process update all data, mark as done and set todo will complate
        Task<TodoResponse> UpdateAsync(int id, Todo todo);
        // process delete data todo list
        Task<TodoResponse> DeleteAsync(int id);
    }
}
