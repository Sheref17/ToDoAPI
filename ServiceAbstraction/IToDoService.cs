using DomainLayer.Entites;
using Shared;

namespace ServiceAbstraction
{
    public interface IToDoService
    {
        Task<bool> CreateTaskAsync(CreatedToDoDto toDo);
        Task<bool> UpdateTaskAsync(Guid id, UpdatedToDoDto toDo);
        Task<bool> DeleteTaskAsync(Guid id);

        Task<IEnumerable<ToDoDto>> GetAllTasksAsync();
        Task<ToDoDetails?> GetTaskByIdAsync(Guid id);

    }
}
