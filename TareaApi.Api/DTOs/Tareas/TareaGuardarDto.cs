namespace TareaApi.Api.DTOs.Tareas;

public class TareaGuardarDto
{
    public string Titulo { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    public bool Completada { get; set; }
}
