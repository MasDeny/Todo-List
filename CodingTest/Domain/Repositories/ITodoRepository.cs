using CodingTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Domain.Repositories
{
    public interface ITodoRepository
    {
        // process show All data also can show specific data
        Task<IEnumerable<Todo>> ListAsync(int ID);

        // process save data
        Task AddAsync(Todo todo);

        // search data on data available or not
        Task<Todo> FindByIdAsync(int id);

        // process update all data, mark as done and set todo will complate
        void Update(Todo todo);

        // delete data todo list
        void Remove(Todo todo);
    }
}
