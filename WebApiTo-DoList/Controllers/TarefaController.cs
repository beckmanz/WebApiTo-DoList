using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTo_DoList.Dto.Tarefa;
using WebApiTo_DoList.Models;
using WebApiTo_DoList.Services.Tarefa;

namespace WebApiTo_DoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaInterface _tarefaInterface;

        public TarefaController(ITarefaInterface tarefaInterface)
        {
            _tarefaInterface = tarefaInterface;
        }
        
        [HttpPost("CriarTarefa")]
        public async Task<ActionResult<ResponseModel<TarefaModel>>> CriarTarefa(CriarTarefaDto criarTarefaDto, int usuarioId)
        {
            var tarefa = await _tarefaInterface.CriarTarefa(criarTarefaDto, usuarioId);
            return Ok(tarefa);
        }

        [HttpPut("EditarTarefa")]
        public async Task<ActionResult<ResponseModel<TarefaModel>>> EditarTarefa(EditarTarefaDto editarTarefaDto, int tarefaId)
        {
            var tarefa = await _tarefaInterface.EditarTarefa(editarTarefaDto, tarefaId);
            return Ok(tarefa);
        }
        [HttpGet("BuscarTarefa")]
        public async Task<ActionResult<ResponseModel<TarefaModel>>> BuscarTarefa(int tarefaId)
        {
            var tarefa = await _tarefaInterface.BuscarTarefa(tarefaId);
            return Ok(tarefa);
        }
        [HttpDelete("ExcluirTarefa")]
        public async Task<ActionResult<ResponseModel<TarefaModel>>> ExcluirTarefa(int tarefaId)
        {
            var tarefa = await _tarefaInterface.ExcluirTarefa(tarefaId);
            return Ok(tarefa);
        }
    }
}
