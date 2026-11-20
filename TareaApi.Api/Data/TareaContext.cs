using TareaApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace TareaApi.Api.Data;

public class TareaContext(DbContextOptions<TareaContext> options) : DbContext(options)
{
    public DbSet<Tarea> Tareas => Set<Tarea>();
}
