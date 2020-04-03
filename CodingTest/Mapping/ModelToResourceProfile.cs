using System;
using System.Linq;
using AutoMapper;
using CodingTest.Domain.Models;
using CodingTest.Resources;
using Newtonsoft.Json;

namespace VisMan.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
        
            CreateMap<Todo,TodoResource>()
                .ReverseMap()
                .ForMember(a => a.Complete, opt => opt.ToString());
        }


    }
}
