﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using vspro.Application.Users.RegisterUser;

namespace vsapro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
