using CodingTest.Domain.Models;
using CodingTest.Domain.Repositories;
using CodingTest.Domain.Services;
using CodingTest.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            // initialize repository for DI
            _todoRepository = todoRepository;
        }

        // get data todo specific data or all data
        public async Task<IEnumerable<Todo>> ListAsync(int ID)
        {
            // Get data shown will process on repository
            return await _todoRepository.ListAsync(ID);
        }

        public async Task<TodoResponse> SaveAsync(Todo todo)
        {
            try
            {
                // data process add data on todolist on repository
                await _todoRepository.AddAsync(todo);

                // data result after save will shown
                return new TodoResponse(todo);
            }
            catch (Exception ex)
            {
                return new TodoResponse($"An error occurred when saving the todo: {ex.Message}");
            }
        }

        public async Task<TodoResponse> UpdateAsync(int id, Todo todo)
        {
            // check available data todo list
            var existingTodo = await _todoRepository.FindByIdAsync(id);

            // if data not found will response this
            if (existingTodo == null)
                return new TodoResponse("Todo List Not Found");

            // if Set Todo percent complete thats will update just complete, Also if mark todo as done will update just status
            existingTodo.Title = todo.Title == null ? existingTodo.Title : todo.Title;
            existingTodo.Description = todo.Description == null ? existingTodo.Description : todo.Description;
            existingTodo.Complete = todo.Complete == 0 ? existingTodo.Complete : todo.Complete;
            existingTodo.Status = todo.Status == 0 ? existingTodo.Status : todo.Status;

            try
            {
                // process update data  on repository
                _todoRepository.Update(existingTodo);

                // data result after update will shown
                return new TodoResponse(existingTodo);
            }

            catch (Exception ex)
            {
                // Do some logging stuff
                return new TodoResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        // Process delete data todolist
        public async Task<TodoResponse> DeleteAsync(int id)
        {
            // check available delete data todo list
            var existingCategory = await _todoRepository.FindByIdAsync(id);

            // if data not found will response this
            if (existingCategory == null)
                return new TodoResponse("Todo List Not Found.");

            try
            {
                //process delete data todo list
                _todoRepository.Remove(existingCategory);

                // result all data after delete will shown
                return new TodoResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TodoResponse($"An error occurred when updating the room meeting : {ex.Message}");
            }
        }
    }
}
