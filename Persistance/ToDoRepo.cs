using DomainLayer;
using DomainLayer.Entites;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;

namespace Persistance
{
    public class ToDoRepo(ToDoContext context) : IToDoRepo
    {
        private readonly ToDoContext _context = context;

        public async Task<bool> CreateAsync(ToDo toDo)
        {
            await _context.Tasks.AddAsync(toDo);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            return await _context.Tasks.AsNoTracking().ToListAsync();
        }

        public async Task<ToDo?> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(ToDo toDo)
        {
            _context.Tasks.Update(toDo);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is null) return false;

            _context.Tasks.Remove(task);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
