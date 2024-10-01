using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTo_DoList.Dto.Usuario;
using WebApiTo_DoList.Models;
using WebApiTo_DoList.Services.Usuario;

namespace WebApiTo_DoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpPost("Criar")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> CriarUsuario(CriarUsuarioDto criarUsuarioDto)
        {
            var usuarios = await _usuarioInterface.CriarUsuario(criarUsuarioDto);
            return Ok(usuarios);
        }
        [HttpPut("Editar")]
        public async Task<ActionResult<ResponseModel<List<UsuarioModel>>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto, string emailUsuario, string passwordUsuario)
        {
            var usuario = await _usuarioInterface.EditarUsuario(editarUsuarioDto, emailUsuario, passwordUsuario);
            return Ok(usuario);
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> BuscarUsuario(int idUsuario)
        {
            var usuario = await _usuarioInterface.BuscarUsuario(idUsuario);
            return Ok(usuario);
        }

        [HttpGet("Login")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> LoginUsuario(string emailUsuario, string passwordUsuario)
        {
            var usuario = await _usuarioInterface.LoginUsuario(emailUsuario, passwordUsuario);
            return Ok(usuario);
        }
        [HttpDelete("Excluir")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> ExcluirUsuario(string emailUsuario, string passwordUsuario)
        {
            var usuario = await _usuarioInterface.ExcluirUsuario(emailUsuario, passwordUsuario);
            return Ok(usuario);
        }
    }
}
