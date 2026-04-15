using AutoMapper;
using DomainLayer;
using DomainLayer.Entites;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ToDoService(IToDoRepo toDoRepo , IMapper mapper) : IToDoService
    {
        private readonly IToDoRepo _toDoRepo = toDoRepo;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> CreateTaskAsync(CreatedToDoDto toDo)
        {
            if (toDo is null || string.IsNullOrWhiteSpace(toDo.Title))
                return false;

            var mappedToDo = _mapper.Map<ToDo>(toDo);
            mappedToDo.CreatedAt = DateTime.Now;
            mappedToDo.LastModifiedAt = DateTime.Now;

          
          return await _toDoRepo.CreateAsync(mappedToDo);
        }

        public async Task<IEnumerable<ToDoDto>> GetAllTasksAsync()
        {
           var tasks = await _toDoRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<ToDoDto>>(tasks);
        }

        public async Task<ToDoDetails?> GetTaskByIdAsync(Guid id)
        {
          var task = await _toDoRepo.GetByIdAsync(id);
            if (task is null) return null;
            var mappedTask = _mapper.Map<ToDoDetails>(task);
            return mappedTask;


        }

        public async Task<bool> UpdateTaskAsync(Guid id, UpdatedToDoDto toDo)
        {
            if (toDo is null)
                return false;

            var existingTask = await _toDoRepo.GetByIdAsync(id);
            if (existingTask is null)
                return false;
            try
            {

                _mapper.Map(toDo, existingTask);

                existingTask.LastModifiedAt = DateTime.Now;

                return await _toDoRepo.UpdateAsync(existingTask);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        
        }
        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            var task = await _toDoRepo.DeleteAsync(id);
            if (!task)
                return false;

            return true;
        }
    }
}
