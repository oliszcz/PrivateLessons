using Microsoft.AspNetCore.Mvc;
using PrivateLessons.Infrastructure.Commands.Interfaces;
using PrivateLessons.Infrastructure.DTO;
using PrivateLessons.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateLessons.Api.Controllers
{
    public class SubjectsController : ApiControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectsController(ISubjectService teacherService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _subjectService = teacherService;
        }

        [HttpGet("{id}")]
        public async Task<SubjectDto> Get(Guid id)
            => await _subjectService.GetSubjectAsync(id);

        [HttpGet]
        public async Task<IEnumerable<SubjectDto>> GetAll()
            => await _subjectService.GetAllSubjectsAsync();

    }
}
