using WebApiTo_DoList.Dto.Tarefa;
using WebApiTo_DoList.Models;

namespace WebApiTo_DoList.Services.Tarefa;

public interface ITarefaInterface
{
    Task<ResponseModel<TarefaModel>> CriarTarefa(CriarTarefaDto criarTarefaDto, int usuarioId);
}