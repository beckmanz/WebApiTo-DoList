﻿using WebApiTo_DoList.Enums;

namespace WebApiTo_DoList.Dto.Tarefa;

public class CriarTarefaDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public StatusTarefa Status { get; set; }
}