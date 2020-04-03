using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodingTest.Domain.Models;
using CodingTest.Domain.Models.Enum;
using CodingTest.Resources;

namespace VisMan.Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveTodoResource, Todo>()
                .ForMember(src => src.Status, opt => opt.MapFrom(src => (EStatus)src.Status));

            CreateMap<TodoResource, Todo>();

        }
    }
}
