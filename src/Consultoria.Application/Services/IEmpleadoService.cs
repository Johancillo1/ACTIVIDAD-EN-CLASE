using Consultoria.Application.DTOs;

namespace Consultoria.Application.Services;

public interface IEmpleadoService
{
    Task<IEnumerable<EmpleadoDto>> GetAllAsync();
    Task<EmpleadoDto?> GetByIdAsync(int id);
    Task<EmpleadoDto> CreateAsync(CreateEmpleadoDto dto);
    Task<EmpleadoDto?> UpdateAsync(int id, UpdateEmpleadoDto dto);
    Task<bool> DeleteAsync(int id);
}
