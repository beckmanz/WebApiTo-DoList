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
    }
}