using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ToDoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime DueDate { get; set; }
    }
}
