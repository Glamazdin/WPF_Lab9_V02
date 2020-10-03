using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Lab9_V02.Domain.Entities;
using Lab9_V02_Business.DTO;

namespace Lab9_V02_Business.Infrastructure
{
    public class MapBootstrapper
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg=> {
                cfg.CreateMap<StudentDTO, Student>();
                
                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<GroupDTO, Group>();
                cfg.CreateMap<Group, GroupDTO>();                   
                   
            });
            return config.CreateMapper();
        }
    }
}
