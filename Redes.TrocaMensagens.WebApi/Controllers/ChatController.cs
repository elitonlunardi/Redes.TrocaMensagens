using Microsoft.AspNetCore.Mvc;
using Redes.TrocaMensagens.Comunicacao.Dtos;

namespace Redes.TrocaMensagens.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    [HttpGet("GetTodosUsuarios")]
    [ProducesResponseType(typeof(UsuariosDto), 200)]
    public IActionResult GetTodosUsuarios()
    {
        // var listaDeUsuarios = new UsuariosDto();
        // listaDeUsuarios.Usuarios = new List<UsuarioDto>()
        // {
        //     new UsuarioDto()
        //     {
        //         UserId = "10",
        //         Username = "20"
        //     },
        //     new UsuarioDto()
        //     {
        //         UserId = "5",
        //         Username = "34"
        //     }
        // };
        return Ok("lista fake");
    }

    [HttpPost("EnviarMensagem")]
    [ProducesResponseType(typeof(IActionResult), 200)]
    public IActionResult EnviarMensagem(EnvioMensagemDto envioMensagemDto)
    {
        return Ok("ok");
    }

    [HttpGet("GetMensagemUserIdPadrao")]
    [ProducesResponseType(typeof(MensagemRecebidaDto), 200)]
    public IActionResult GetMensagemUserIdPadrao()
    {
        return Ok(new MensagemRecebidaDto
        {
            UserId = "12345",
            Mensagem = "mensagem fake"
        });
    }
}