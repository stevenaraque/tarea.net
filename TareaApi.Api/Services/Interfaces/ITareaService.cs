using TareaApi.Api.DTOs.Tareas;

namespace TareaApi.Api.Services.Interfaces;

public interface ITareaService
{
    Task<List<TareaDto>> ListarAsync();

    Task<TareaDto> CrearAsync(TareaGuardarDto dto);
}
