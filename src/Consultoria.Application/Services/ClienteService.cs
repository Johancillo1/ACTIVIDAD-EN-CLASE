using Consultoria.Application.DTOs;
using Consultoria.Application.Interfaces;
using Consultoria.Domain.Entities;

namespace Consultoria.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var clientes = await _unitOfWork.Repository<Cliente>().GetAllAsync();
        return clientes.Select(MapToDto);
    }

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var cliente = await _unitOfWork.Repository<Cliente>().GetByIdAsync(id);
        return cliente is null ? null : MapToDto(cliente);
    }

    public async Task<ClienteDto> CreateAsync(CreateClienteDto dto)
    {
        var cliente = new Cliente
        {
            NombreContacto = dto.NombreContacto,
            Empresa = dto.Empresa,
            Email = dto.Email,
            Telefono = dto.Telefono
        };

        await _unitOfWork.Repository<Cliente>().AddAsync(cliente);
        await _unitOfWork.CompleteAsync();
        return MapToDto(cliente);
    }

    public async Task<ClienteDto?> UpdateAsync(int id, UpdateClienteDto dto)
    {
        var cliente = await _unitOfWork.Repository<Cliente>().GetByIdAsync(id);
        if (cliente is null) return null;

        cliente.NombreContacto = dto.NombreContacto;
        cliente.Empresa = dto.Empresa;
        cliente.Email = dto.Email;
        cliente.Telefono = dto.Telefono;

        _unitOfWork.Repository<Cliente>().Update(cliente);
        await _unitOfWork.CompleteAsync();
        return MapToDto(cliente);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cliente = await _unitOfWork.Repository<Cliente>().GetByIdAsync(id);
        if (cliente is null) return false;

        _unitOfWork.Repository<Cliente>().Delete(cliente);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    private static ClienteDto MapToDto(Cliente cliente) => new()
    {
        IdCliente = cliente.IdCliente,
        NombreContacto = cliente.NombreContacto,
        Empresa = cliente.Empresa,
        Email = cliente.Email,
        Telefono = cliente.Telefono
    };
}
