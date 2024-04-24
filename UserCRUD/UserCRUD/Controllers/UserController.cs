using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserCRUD.Domain.Queries.Request;

namespace UserCRUD.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _mediator.Send(new GeAllUsersQuery());

            return Ok(users);
        }

    }
}
