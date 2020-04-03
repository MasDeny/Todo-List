using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodingTest.Domain.Models;
using CodingTest.Domain.Services;
using CodingTest.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisMan.Api.Extensions;

namespace CodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodoController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        // Get All Todos or Specific Todo
        // 1. To get all data https://localhost:5001/api/todo
        // 2. To Get Specific data https://localhost:5001/api/todo?Id={id}
        [HttpGet]
        public async Task<IEnumerable<TodoResource>> GetAllAsync([FromQuery]int ID)
        {
            var Todos = await _todoService.ListAsync(ID);
            var resources = _mapper.Map<IEnumerable<Todo>, IEnumerable<TodoResource>>(Todos);

            if(resources.Count() == 0)
            {
                return null;
            }

            return resources;
        }

        // Create Todos
        // https://localhost:5001/api/todo
        // fill with data raw
        //{
	    //  "title" : "Ini Todo pertama",
	    //  "description" : "GelekTawa",
	    //  "timeexpired" : "2019-11-17 14:29:21"
        //}

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTodoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var todos = _mapper.Map<SaveTodoResource, Todo>(resource);
            var result = await _todoService.SaveAsync(todos);

            if (!result.Success)
                return BadRequest(result.Message);

            var TodoResult = _mapper.Map<Todo, TodoResource>(result.Todo);
            return Ok(TodoResult);
        }

        // Update all data Todos by id
        // url : https://localhost:5001/api/todo/{id}
        // update fill data raw
        //    {
        //      "title": "Ini Todo pertama",
        //      "description": "GelekTawa",
        //      "timeExpired": "2020-02-17T14:29:21"
        //    }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] TodoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var todos = _mapper.Map<TodoResource, Todo>(resource);
            var result = await _todoService.UpdateAsync(id, todos);

            if (!result.Success)
                return BadRequest(result.Message);
            var todoResult = _mapper.Map<Todo, TodoResource>(result.Todo);
            return Ok(todoResult);
        }

        // update complete data by id todo list
        // https://localhost:5001/api/todo/complete/{id}
        // raw data fill
        //  {
        //    "complete": 80,
        //  }
        [HttpPut("complete/{id}")]
        public async Task<IActionResult> CompletePutAsync(int id, [FromBody] TodoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var todos = _mapper.Map<TodoResource, Todo>(resource);
            var result = await _todoService.UpdateAsync(id, todos);

            if (!result.Success)
                return BadRequest(result.Message);
            var todoResult = _mapper.Map<Todo, TodoResource>(result.Todo);
            return Ok(todoResult);
        }

        // update status done data by id todo list
        // https://localhost:5001/api/todo/status/{id}
        // raw data fill 
        //  {
        //    "complete": 100,
        //    "status": "Done"
        //  }
        [HttpPut("status/{id}")]
        public async Task<IActionResult> DonePutAsync(int id, [FromBody] TodoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var todos = _mapper.Map<TodoResource, Todo>(resource);
            var result = await _todoService.UpdateAsync(id, todos);

            if (!result.Success)
                return BadRequest(result.Message);
            var todoResult = _mapper.Map<Todo, TodoResource>(result.Todo);
            return Ok(todoResult);
        }

        // Delete data by id
        // url : https://localhost:5001/api/todo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _todoService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(new { message = "Data Todo List Has Been Deleted" });
        }
    }
}