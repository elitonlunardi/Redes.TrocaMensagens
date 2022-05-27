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
        var usuarios = _larcClient.ObterUsuarios();
        return Ok(usuarios);
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
        var mensagem = _larcClient.ObterMensagemParaUsuarioPadrao();
        return Ok(mensagem);
    }
}