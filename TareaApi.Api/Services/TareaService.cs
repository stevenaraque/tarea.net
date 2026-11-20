using TareaApi.Api.Data;
using TareaApi.Api.DTOs.Tareas;
using TareaApi.Api.Models;
using TareaApi.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TareaApi.Api.Services;

public class TareaService(TareaContext db) : ITareaService
{
    public async Task<List<TareaDto>> ListarAsync()
    {
        return await db.Tareas
            .OrderBy(t => t.Id)
            .Select(t => new TareaDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                Completada = t.Completada,
                FechaCreacion = t.FechaCreacion
            })
            .ToListAsync();
    }

    public async Task<TareaDto> CrearAsync(TareaGuardarDto dto)
    {
        var tarea = new Tarea
        {
            Titulo = dto.Titulo.Trim(),
            Descripcion = string.IsNullOrWhiteSpace(dto.Descripcion)
                ? null
                : dto.Descripcion.Trim(),
            Completada = dto.Completada
        };

        db.Tareas.Add(tarea);
        await db.SaveChangesAsync();

        return new TareaDto
        {
            Id = tarea.Id,
            Titulo = tarea.Titulo,
            Descripcion = tarea.Descripcion,
            Completada = tarea.Completada,
            FechaCreacion = tarea.FechaCreacion
        };
    }
}
