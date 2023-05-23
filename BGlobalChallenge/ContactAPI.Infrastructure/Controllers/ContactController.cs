using ContactAPI.Application.Contact.Create;
using ContactAPI.Application.Contact.Delete;
using ContactAPI.Application.Contact.Queries;
using ContactAPI.Application.Contact.Update;
using ContactAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactAPI.Infrastructure.Controllers;

public class ContactController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Contact>>> GetAll(
        [FromQuery] GetAllContactsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> Get(int id)
    {
        return await Mediator.Send(new GetContactQuery(id));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateContactCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Contact>> Update(int id, UpdateContactCommand command)
    {
        if (id != command.Id) return BadRequest();

        return await Mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Update(int id)
    {
        await Mediator.Send(new DeleteContactCommand(id));

        return Ok();
    }
}