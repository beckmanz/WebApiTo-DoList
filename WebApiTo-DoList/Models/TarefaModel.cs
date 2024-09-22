using WebApiTo_DoList.Enums;

namespace WebApiTo_DoList.Models;

public class TarefaModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public StatusTarefa Status { get; set; }
    public UsuarioModel Usuario { get; set; }
}