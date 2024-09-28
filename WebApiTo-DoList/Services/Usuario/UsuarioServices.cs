using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiTo_DoList.Data;
using WebApiTo_DoList.Dto.Usuario;
using WebApiTo_DoList.Models;

namespace WebApiTo_DoList.Services.Usuario;

public class UsuarioServices : IUsuarioInterface
{
    private readonly ApplicationDbContext _context;

    public UsuarioServices(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseModel<UsuarioModel>> CriarUsuario(CriarUsuarioDto criarUsuarioDto)
    {
        ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();
        try
        {
            var usuario = await _context.Usuarios.AnyAsync(u => u.Email == criarUsuarioDto.Email);
            
            if (usuario)
            {
                resposta.Mensagem = "Já existe um usuário registrado com esse email, use outro email!!";
                return resposta;
            }
            
            var HashPassword = BCrypt.Net.BCrypt.HashPassword(criarUsuarioDto.Password);
            
            var newUsuario = new UsuarioModel()
            {
                Name = criarUsuarioDto.Name,
                Email = criarUsuarioDto.Email,
                Password = HashPassword
            };

            _context.Add(newUsuario);
            await _context.SaveChangesAsync();

            resposta.Dados = newUsuario;
            resposta.Mensagem = "Usuário Criado com sucesso!!";
            resposta.Status = true;

            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;

        }
    }

    public async Task<ResponseModel<UsuarioModel>> EditarUsuario(EditarUsuarioDto editarUsuarioDto, string emailUsuario, string passwordUsuario)
    {
        ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();
        try
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == emailUsuario);
            if (usuario == null)
            {
                resposta.Mensagem = "Usuário não encontrado, verifique o email e tente novamente!!";
                return resposta;
            }

            if (!BCrypt.Net.BCrypt.Verify(passwordUsuario, usuario.Password))
            {
                resposta.Mensagem = "Senha incorreta, verifique a senha e tente novamente!!";
                return resposta;
            }
            
            var email = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == editarUsuarioDto.Email);
            if (email.Id != usuario.Id)
            {
                resposta.Mensagem = "Já existe um usuário registrado com esse email, use outro email!!";
                return resposta;
            }
            
            var HashPassword = BCrypt.Net.BCrypt.HashPassword(editarUsuarioDto.Password);

            usuario.Name = editarUsuarioDto.Name;
            usuario.Email = editarUsuarioDto.Email;
            usuario.Password = HashPassword;
            

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            resposta.Dados = usuario;
            resposta.Mensagem = "Usuário editado com sucesso!!";
            resposta.Status = true;

            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;

        }
    }

    public async Task<ResponseModel<UsuarioModel>> BuscarUsuario(int idUsuario)
    {
        ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();
        try
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == idUsuario);
            
            if (usuario == null)
            {
                resposta.Mensagem = "Usuário não encontrado!!";
                return resposta;
            }

            resposta.Dados = usuario;
            resposta.Mensagem = "Usuário encontrado com sucesso!!";
            resposta.Status = true;

            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;

        }
    }

    public async Task<ResponseModel<UsuarioModel>> LoginUsuario(string emailUsuario, string passwordUsuario)
    {
        ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();
        try
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == emailUsuario);
            
            if (usuario == null)
            {
                resposta.Mensagem = "Usuário não encontrado, verifique o email e tente novamente!!";
                return resposta;
            }

            if (!BCrypt.Net.BCrypt.Verify(passwordUsuario, usuario.Password))
            {
                resposta.Mensagem = "Senha incorreta, verifique a senha e tente novamente!!";
                return resposta;
            }

            resposta.Dados = usuario;
            resposta.Mensagem = "Usuário logado com sucesso!!";
            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<UsuarioModel>> ExcluirUsuario(string emailUsuario, string passwordUsuario)
    {
        ResponseModel<UsuarioModel> resposta = new ResponseModel<UsuarioModel>();
        try
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == emailUsuario);
            
            if (usuario == null)
            {
                resposta.Mensagem = "Usuário não encontrado, verifique o email e tente novamente!!";
                return resposta;
            }

            if (!BCrypt.Net.BCrypt.Verify(passwordUsuario, usuario.Password))
            {
                resposta.Mensagem = "Senha incorreta, verifique a senha e tente novamente!!";
                return resposta;
            }
            
            _context.Remove(usuario);
            await _context.SaveChangesAsync();

            resposta.Dados = usuario;
            resposta.Mensagem = "Usuário deletado com sucesso!!";
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