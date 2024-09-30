using WebApiTo_DoList.Dto.Tarefa;
using WebApiTo_DoList.Models;

namespace WebApiTo_DoList.Services.Tarefa;

public interface ITarefaInterface
{
    Task<ResponseModel<TarefaModel>> CriarTarefa(CriarTarefaDto criarTarefaDto, int usuarioId);
    Task<ResponseModel<TarefaModel>> EditarTarefa(EditarTarefaDto editarTarefaDto, int tarefaId);
    Task<ResponseModel<TarefaModel>> BuscarTarefa(int tarefaId);
    Task<ResponseModel<TarefaModel>> ExcluirTarefa(int tarefaId);

}