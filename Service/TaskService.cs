using ToDoListAPI.Models;
using ToDoListAPI.Models.DTOs;
using ToDoListAPI.Service.IService;

namespace ToDoListAPI.Service
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TaskService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TaskResponse>> GetAllTaskAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return _mapper.Map<List<TaskResponse>>(tasks);
        }

        public async Task<TaskResponse> GetTaskByIdAsync(Guid taskId)
        {
            var task = await _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if(task == null) return null;
            return _mapper.Map<TaskResponse>(task);
        }

        public async Task<TaskResponse> AddTaskAsync(CreateUpdateTaskDto newTaskDto)
        {
            var task = _mapper.Map<TodoTask>(newTaskDto);
            task.Id = Guid.NewGuid();
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaskResponse>(task);

        }

        public async Task UpdateTaskAsync(CreateUpdateTaskDto updatedTaskDto, Guid taskId)
        {
            var existing = await _context.Tasks.FindAsync(taskId);
            if(existing == null) return;
            _mapper.Map(updatedTaskDto, existing);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteTaskAsync(Guid taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if(task == null) return;
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
        
    }
}