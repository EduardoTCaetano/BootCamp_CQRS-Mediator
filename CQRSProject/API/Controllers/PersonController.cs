using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CQRSApp.Application.Commands;
using CQRSApp.Application.Queries;
using CQRSApp.Domain.Entities;
using CQRSApp.Application.Handlers;

namespace CQRSApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            var query = new GetPersonByIdQuery(id);
            var person = await _mediator.Send(query);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var query = new GetAllPersonsQuery();
            var persons = await _mediator.Send(query);
            return Ok(persons);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePerson(Guid id, [FromBody] UpdatePersonCommand command)
        {
            var result = await _mediator.Send(new UpdatePersonCommand(id, command.Name, command.Age, command.TaxId));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }



        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var command = new DeletePersonCommand(id);
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
