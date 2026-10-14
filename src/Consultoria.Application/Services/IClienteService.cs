using Consultoria.Application.DTOs;

namespace Consultoria.Application.Services;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> GetAllAsync();
    Task<ClienteDto?> GetByIdAsync(int id);
    Task<ClienteDto> CreateAsync(CreateClienteDto dto);
    Task<ClienteDto?> UpdateAsync(int id, UpdateClienteDto dto);
    Task<bool> DeleteAsync(int id);
}
