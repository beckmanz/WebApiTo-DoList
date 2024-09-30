using Microsoft.EntityFrameworkCore;
using WebApiTo_DoList.Data;
using WebApiTo_DoList.Dto.Tarefa;
using WebApiTo_DoList.Models;

namespace WebApiTo_DoList.Services.Tarefa;

public class TarefaServices : ITarefaInterface
{
    private readonly ApplicationDbContext _context;
    public TarefaServices(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseModel<TarefaModel>> CriarTarefa(CriarTarefaDto criarTarefaDto, int usuarioId)
    {
        ResponseModel<TarefaModel> resposta = new ResponseModel<TarefaModel>();
        try
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioId);
            if (usuario == null)
            {
                resposta.Mensagem = "Usuário não encontrado, verifique o Id e tente novamente!!";
                return resposta;
            }

            var tarefa = new TarefaModel()
            {
                Name = criarTarefaDto.Name,
                Description = criarTarefaDto.Description,
                Status = criarTarefaDto.Status,
                Usuario = usuario
            };
            
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();

            resposta.Dados = tarefa;
            resposta.Mensagem = "Tarefa criada com sucesso!";
            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
}