using CodingTest.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Data.Repositories
{
    // initiate repository to use DI
    public abstract class BaseRepository
    {
        protected readonly ToDoDbContext _context;

        public BaseRepository(ToDoDbContext context)
        {
            _context = context;
        }
    }
}
