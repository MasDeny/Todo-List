using CodingTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Services.Communication
{
    // set default response 
    public class TodoResponse : BaseResponse
    {
        public Todo Todo { get; private set; }



        private TodoResponse(bool success, string message, Todo todo) : base(success, message)
        {

            Todo = todo;

        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="visitor">Saved category.</param>
        /// <returns>Response.</returns>
        public TodoResponse(Todo todo) : this(true, string.Empty, todo)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TodoResponse(string message) : this(false, message, null)
        { }


    }
}
