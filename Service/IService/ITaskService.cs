using ToDoListAPI.Models;
using ToDoListAPI.Models.DTOs;

namespace ToDoListAPI.Service.IService
{
    public interface ITaskService
    {
        Task <List<TaskResponse>> GetAllTaskAsync();
        Task <TaskResponse> GetTaskByIdAsync(Guid taskId);
        Task <TaskResponse> AddTaskAsync(CreateUpdateTaskDto newTaskDto);
        Task UpdateTaskAsync(CreateUpdateTaskDto updatedTaskDto, Guid taskId);
        Task DeleteTaskAsync(Guid taskId);
        
    }

}