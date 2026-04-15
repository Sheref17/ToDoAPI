using DomainLayer.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Data
{
    public class ToDoContext :DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext>opt):base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration( new ToDoConfigrution());
         
        }
        public DbSet<ToDo> Tasks { get; set; }
    }
}
