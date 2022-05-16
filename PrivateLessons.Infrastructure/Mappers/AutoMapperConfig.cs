using AutoMapper;
using PrivateLessons.Core.Domain;
using PrivateLessons.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLessons.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Subject, SubjectDto>();
                cfg.CreateMap<Teacher, TeacherDto>();
            })
            .CreateMapper();
    }
}
