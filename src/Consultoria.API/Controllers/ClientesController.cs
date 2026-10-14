using Consultoria.Application.DTOs;
using Consultoria.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consultoria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> GetAll()
        => Ok(await _clienteService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClienteDto>> GetById(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        return cliente is null ? NotFound() : Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDto>> Create(CreateClienteDto dto)
    {
        var created = await _clienteService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.IdCliente }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ClienteDto>> Update(int id, UpdateClienteDto dto)
    {
        var updated = await _clienteService.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _clienteService.DeleteAsync(id) ? NoContent() : NotFound();
}
