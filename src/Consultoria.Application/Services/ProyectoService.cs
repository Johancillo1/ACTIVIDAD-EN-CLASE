using Consultoria.Application.DTOs;
using Consultoria.Application.Interfaces;
using Consultoria.Domain.Entities;

namespace Consultoria.Application.Services;

public class ProyectoService : IProyectoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProyectoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProyectoDto>> GetAllAsync()
    {
        var proyectos = await _unitOfWork.Repository<Proyecto>().GetAllAsync();
        return proyectos.Select(MapToDto);
    }

    public async Task<ProyectoDto?> GetByIdAsync(int id)
    {
        var proyecto = await _unitOfWork.Repository<Proyecto>().GetByIdAsync(id);
        return proyecto is null ? null : MapToDto(proyecto);
    }

    public async Task<ProyectoDto> CreateAsync(CreateProyectoDto dto)
    {
        var proyecto = new Proyecto
        {
            IdCliente = dto.IdCliente,
            IdResponsable = dto.IdResponsable,
            Nombre = dto.Nombre,
            Objetivos = dto.Objetivos,
            FechaInicio = dto.FechaInicio,
            FechaFin = dto.FechaFin,
            PresupuestoEstimado = dto.PresupuestoEstimado,
            Estado = dto.Estado
        };

        await _unitOfWork.Repository<Proyecto>().AddAsync(proyecto);
        await _unitOfWork.CompleteAsync();
        return MapToDto(proyecto);
    }

    public async Task<ProyectoDto?> UpdateAsync(int id, UpdateProyectoDto dto)
    {
        var proyecto = await _unitOfWork.Repository<Proyecto>().GetByIdAsync(id);
        if (proyecto is null) return null;

        proyecto.IdCliente = dto.IdCliente;
        proyecto.IdResponsable = dto.IdResponsable;
        proyecto.Nombre = dto.Nombre;
        proyecto.Objetivos = dto.Objetivos;
        proyecto.FechaInicio = dto.FechaInicio;
        proyecto.FechaFin = dto.FechaFin;
        proyecto.PresupuestoEstimado = dto.PresupuestoEstimado;
        proyecto.Estado = dto.Estado;

        _unitOfWork.Repository<Proyecto>().Update(proyecto);
        await _unitOfWork.CompleteAsync();
        return MapToDto(proyecto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var proyecto = await _unitOfWork.Repository<Proyecto>().GetByIdAsync(id);
        if (proyecto is null) return false;

        _unitOfWork.Repository<Proyecto>().Delete(proyecto);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    private static ProyectoDto MapToDto(Proyecto proyecto) => new()
    {
        IdProyecto = proyecto.IdProyecto,
        IdCliente = proyecto.IdCliente,
        IdResponsable = proyecto.IdResponsable,
        Nombre = proyecto.Nombre,
        Objetivos = proyecto.Objetivos,
        FechaInicio = proyecto.FechaInicio,
        FechaFin = proyecto.FechaFin,
        PresupuestoEstimado = proyecto.PresupuestoEstimado,
        Estado = proyecto.Estado
    };
}
