using Microsoft.AspNetCore.Mvc;
using Redes.TrocaMensagens.Comunicacao.Dtos;
using Redes.TrocaMensagens.Comunicacao.Interfaces;

namespace Redes.TrocaMensagens.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    private readonly ILarcClient _larcClient;

    public ChatController(ILarcClient larcClient)
    {
        _larcClient = larcClient;
    }

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
        var mensagemEnviadaComSucesso = _larcClient.EnviarMensagem(envioMensagemDto);
        return Ok(mensagemEnviadaComSucesso);
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