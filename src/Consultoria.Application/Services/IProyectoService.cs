using Consultoria.Application.DTOs;

namespace Consultoria.Application.Services;

public interface IProyectoService
{
    Task<IEnumerable<ProyectoDto>> GetAllAsync();
    Task<ProyectoDto?> GetByIdAsync(int id);
    Task<ProyectoDto> CreateAsync(CreateProyectoDto dto);
    Task<ProyectoDto?> UpdateAsync(int id, UpdateProyectoDto dto);
    Task<bool> DeleteAsync(int id);
}
