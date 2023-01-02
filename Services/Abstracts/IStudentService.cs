﻿using DataAccess.Entities;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstracts
{
    public interface IStudentService : IBaseService<StudentDTO, Student, StudentDTO>
    {
    }
}