using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using DTOs;
using Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concretes
{
    public class StudentService : BaseService<StudentDTO, Student, StudentDTO>, IStudentService
    {
        public StudentService(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
        {
        }
    }
}