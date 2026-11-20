using TareaApi.Api.DTOs.Tareas;
using TareaApi.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TareaApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareasController(ITareaService servicio) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TareaDto>>> Listar()
    {
        return Ok(await servicio.ListarAsync());
    }

    [HttpPost]
    public async Task<ActionResult<TareaDto>> Crear(TareaGuardarDto dto)
    {
        var creado = await servicio.CrearAsync(dto);
        return CreatedAtAction(nameof(Listar), new { id = creado.Id }, creado);
    }
}
