using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class CreatedToDoDto
    {
  
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string Status { get; set; } = default!;
        public string Priority { get; set; } = default!;
        public DateTime DueDate { get; set; }
 
    }
}
