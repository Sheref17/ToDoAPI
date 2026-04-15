using DomainLayer.Entites;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PersentaisonLayer
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController(IToDoService toDoService) : ControllerBase
    {
        private readonly IToDoService _toDoService = toDoService;
        [HttpPost("CreateTask")]
        public async Task<ActionResult> AddTask(CreatedToDoDto toDo)
        {
            var res = await _toDoService.CreateTaskAsync(toDo);
            if (!res) return BadRequest("Failed To Create Task");
            return Ok("Task Created successfully");

        }
        [HttpGet("GetAllTasks")]
        public async Task<ActionResult<IEnumerable<ToDoDto>>> GetAllTasks()
        {
            var tasks = await _toDoService.GetAllTasksAsync();
            if (!tasks.Any()) return null;
            return Ok(tasks);

        }
        [HttpPut("UpdateTask/{id}")]
        public async Task<ActionResult<UpdatedToDoDto>> UpdateTask( Guid id,UpdatedToDoDto updatedToDo)
        {
            var res = await _toDoService.UpdateTaskAsync( id,updatedToDo);
            if (!res) return BadRequest("Failed To Update");
            return Ok("Updated successfully");
            
        }
        [HttpDelete("DeleteTask/{id}")]
        public async Task<ActionResult<bool>> DeleteTask (Guid id)
        {
            var res = await _toDoService.DeleteTaskAsync(id);
            if (!res) return BadRequest("Failed To Delete");
            return Ok("Task Deleted Successfully");
        }
        [HttpGet("DetailedTask/{id}")]
        public async Task<ActionResult<CreatedToDoDto>> GetTaskById(Guid id)
        {
            var task = await _toDoService.GetTaskByIdAsync(id);
            if (task is null) return BadRequest("Task Is Not Found");
            return Ok(task);

        }
        
    }
}
