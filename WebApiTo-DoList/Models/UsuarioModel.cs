﻿namespace WebApiTo_DoList.Models;

public class UsuarioModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<TarefaModel> Tarefas { get; set; }
}