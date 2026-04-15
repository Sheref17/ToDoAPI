using AutoMapper;
using DomainLayer.Entites;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<CreatedToDoDto, ToDo>()
               .ForMember(x => x.Status,
                   opt => opt.MapFrom(x => ParseStatus(x.Status)))
               .ForMember(x => x.Priority,
                   opt => opt.MapFrom(x => ParsePriority(x.Priority)));
            CreateMap<ToDo, ToDoDetails>()
             .ForMember(x => x.Status,
                 opt => opt.MapFrom(x => x.Status.ToString()))
             .ForMember(x => x.Priority,
                 opt => opt.MapFrom(x => x.Priority.ToString()));

            CreateMap<UpdatedToDoDto, ToDo>()
                .ForMember(x => x.Status,
                    opt => opt.MapFrom(x => ParseStatus(x.Status)))
                .ForMember(x => x.Priority,
                    opt => opt.MapFrom(x => ParsePriority(x.Priority)));

            CreateMap<ToDo, ToDoDto>();
     

        }

        private static Status ParseStatus(string value)
        {
            return Enum.TryParse<Status>(value, true, out var result)
                ? result
                : Status.Pending;
        }

        private static Priority ParsePriority(string value)
        {
            return Enum.TryParse<Priority>(value, true, out var result)
                ? result
                : Priority.Low;
        }
    }
}
