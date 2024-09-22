using Microsoft.EntityFrameworkCore;
using WebApiTo_DoList.Models;

namespace WebApiTo_DoList.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UsuarioModel> Usuario { get; set; }
    public DbSet<TarefaModel> Tarefa { get; set; }
}