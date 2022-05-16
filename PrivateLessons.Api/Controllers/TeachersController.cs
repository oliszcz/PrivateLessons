using Microsoft.AspNetCore.Mvc;
using PrivateLessons.Infrastructure.Commands.Interfaces;
using PrivateLessons.Infrastructure.DTO;
using PrivateLessons.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrivateLessons.Api.Controllers
{
    public class TeachersController : ApiControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _teacherService = teacherService;
        }

        [HttpGet("{userId}")]
        public async Task<TeacherDto> Get(Guid userId)
            => await _teacherService.GetTeacherAsync(userId);

        [HttpGet]
        public async Task<IEnumerable<TeacherDto>> GetAll()
            => await _teacherService.GetAllTeachersAsync();

    }
}
