using Consultoria.Application.DTOs;
using Consultoria.Application.Interfaces;
using Consultoria.Domain.Entities;

namespace Consultoria.Application.Services;

public class EmpleadoService : IEmpleadoService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmpleadoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<EmpleadoDto>> GetAllAsync()
    {
        var empleados = await _unitOfWork.Repository<Empleado>().GetAllAsync();
        return empleados.Select(MapToDto);
    }

    public async Task<EmpleadoDto?> GetByIdAsync(int id)
    {
        var empleado = await _unitOfWork.Repository<Empleado>().GetByIdAsync(id);
        return empleado is null ? null : MapToDto(empleado);
    }

    public async Task<EmpleadoDto> CreateAsync(CreateEmpleadoDto dto)
    {
        var empleado = new Empleado
        {
            Nombre = dto.Nombre,
            Email = dto.Email,
            Rol = dto.Rol,
            Activo = dto.Activo
        };

        await _unitOfWork.Repository<Empleado>().AddAsync(empleado);
        await _unitOfWork.CompleteAsync();
        return MapToDto(empleado);
    }

    public async Task<EmpleadoDto?> UpdateAsync(int id, UpdateEmpleadoDto dto)
    {
        var empleado = await _unitOfWork.Repository<Empleado>().GetByIdAsync(id);
        if (empleado is null) return null;

        empleado.Nombre = dto.Nombre;
        empleado.Email = dto.Email;
        empleado.Rol = dto.Rol;
        empleado.Activo = dto.Activo;

        _unitOfWork.Repository<Empleado>().Update(empleado);
        await _unitOfWork.CompleteAsync();
        return MapToDto(empleado);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var empleado = await _unitOfWork.Repository<Empleado>().GetByIdAsync(id);
        if (empleado is null) return false;

        _unitOfWork.Repository<Empleado>().Delete(empleado);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    private static EmpleadoDto MapToDto(Empleado empleado) => new()
    {
        IdEmpleado = empleado.IdEmpleado,
        Nombre = empleado.Nombre,
        Email = empleado.Email,
        Rol = empleado.Rol,
        Activo = empleado.Activo
    };
}
