using Microsoft.AspNetCore.Mvc;
using PrivateLessons.Infrastructure.Commands.Interfaces;

namespace PrivateLessons.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispatcher _commandDispatcher;
        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
    }
}
