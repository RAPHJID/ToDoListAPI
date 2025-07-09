using ToDoListAPI.Service.IService;
using ToDoListAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllTask()
        {
            var tasks = await _service.GetAllTaskAsync();
            return Ok(tasks);
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskById(Guid taskId)
        {
            var task = await _service.GetTaskByIdAsync(taskId);
            var response = new ResponseDto();
            if(task == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Task with ID : {taskId} not found!";
                return NotFound(response);
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(CreateUpdateTaskDto newTask)
        {
            await _service.AddTaskAsync(newTask);
            return Ok(newTask);
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(CreateUpdateTaskDto updatedTask, Guid taskId)
        {
            var existing = await _service.GetTaskByIdAsync(taskId);
            var response = new ResponseDto();
            if(existing == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Task with ID:{taskId} does not exist";
                return NotFound(response);
            }
            await _service.UpdateTaskAsync(updatedTask, taskId);
            return Ok(updatedTask);
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            var task = await _service.GetTaskByIdAsync(taskId);
            var response = new ResponseDto();
            if(task == null)
            {
                response.Success = false;
                response.ErrorMessage = $"Task with ID: {taskId} not found";
                return NotFound(response);
            }
            await _service.DeleteTaskAsync(taskId);
            return Ok($"Task with ID {taskId} Deleted");
        }


        
    }

}