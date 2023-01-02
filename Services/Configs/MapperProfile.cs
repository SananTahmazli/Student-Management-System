﻿using AutoMapper;
using DataAccess.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Configs
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}