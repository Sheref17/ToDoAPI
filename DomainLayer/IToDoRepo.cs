using DomainLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public interface IToDoRepo
    {
        Task<bool> CreateAsync(ToDo toDo);
        Task<bool> UpdateAsync(ToDo toDo);
        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<ToDo>> GetAllAsync();
        Task<ToDo?> GetByIdAsync(Guid id);
    }
}
