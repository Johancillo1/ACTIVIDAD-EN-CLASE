using Consultoria.Application.DTOs;
using Consultoria.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consultoria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private readonly IEmpleadoService _empleadoService;

    public EmpleadosController(IEmpleadoService empleadoService)
    {
        _empleadoService = empleadoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetAll()
        => Ok(await _empleadoService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmpleadoDto>> GetById(int id)
    {
        var empleado = await _empleadoService.GetByIdAsync(id);
        return empleado is null ? NotFound() : Ok(empleado);
    }

    [HttpPost]
    public async Task<ActionResult<EmpleadoDto>> Create(CreateEmpleadoDto dto)
    {
        var created = await _empleadoService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.IdEmpleado }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<EmpleadoDto>> Update(int id, UpdateEmpleadoDto dto)
    {
        var updated = await _empleadoService.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _empleadoService.DeleteAsync(id) ? NoContent() : NotFound();
}
