using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTo_DoList.Models;

namespace WebApiTo_DoList.Data.Map;

public class TarefasMap : IEntityTypeConfiguration<TarefaModel>
{
    public void Configure(EntityTypeBuilder<TarefaModel> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).IsRequired().HasMaxLength(254);
        builder.Property(t => t.Description).HasMaxLength(1000);
        builder.HasOne(t => t.Usuario);
    }
}