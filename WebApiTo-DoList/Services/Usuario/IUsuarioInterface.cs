using WebApiTo_DoList.Dto.Usuario;
using WebApiTo_DoList.Models;

namespace WebApiTo_DoList.Services.Usuario;

public interface IUsuarioInterface
{
    Task<ResponseModel<UsuarioModel>> CriarUsuario(CriarUsuarioDto criarUsuarioDto);
    Task<ResponseModel<UsuarioModel>> EditarUsuario(EditarUsuarioDto editarUsuarioDto, string emailUsuario, string passwordUsuario);
    Task<ResponseModel<UsuarioModel>> BuscarUsuario(int idUsuario);
    Task<ResponseModel<UsuarioModel>> LoginUsuario(string emailUsuario, string passwordUsuario);
    Task<ResponseModel<UsuarioModel>> ExcluirUsuario(string emailUsuario, string passwordUsuario);

}