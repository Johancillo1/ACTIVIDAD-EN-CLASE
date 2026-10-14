using Consultoria.Application.DTOs;
using Consultoria.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consultoria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectosController : ControllerBase
{
    private readonly IProyectoService _proyectoService;

    public ProyectosController(IProyectoService proyectoService)
    {
        _proyectoService = proyectoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProyectoDto>>> GetAll()
        => Ok(await _proyectoService.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProyectoDto>> GetById(int id)
    {
        var proyecto = await _proyectoService.GetByIdAsync(id);
        return proyecto is null ? NotFound() : Ok(proyecto);
    }

    [HttpPost]
    public async Task<ActionResult<ProyectoDto>> Create(CreateProyectoDto dto)
    {
        var created = await _proyectoService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.IdProyecto }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProyectoDto>> Update(int id, UpdateProyectoDto dto)
    {
        var updated = await _proyectoService.UpdateAsync(id, dto);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => await _proyectoService.DeleteAsync(id) ? NoContent() : NotFound();
}
