using Microsoft.EntityFrameworkCore;
using WebApiTo_DoList.Data.Map;
using WebApiTo_DoList.Models;

namespace WebApiTo_DoList.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<TarefaModel> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new TarefasMap());
        base.OnModelCreating(modelBuilder);
    }
}