using System.Net.Sockets;
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
        try
        {
            var usuarios = _larcClient.ObterUsuarios();
            return Ok(usuarios);
        }
        catch (Exception)
        {
            return StatusCode(500, "Falha ao estalecer conexão com o servidor.");
        }
    }

    [HttpPost("EnviarMensagem")]
    [ProducesResponseType(typeof(IActionResult), 200)]
    public IActionResult EnviarMensagem(EnvioMensagemDto envioMensagemDto)
    {
        try
        {
            var mensagemEnviadaComSucesso = _larcClient.EnviarMensagem(envioMensagemDto);
            return Ok(mensagemEnviadaComSucesso);
        }
        catch (Exception)
        {
            return StatusCode(500, "Falha ao estalecer conexão com o servidor.");
        }
    }

    [HttpGet("GetMensagemUserIdPadrao")]
    [ProducesResponseType(typeof(MensagemRecebidaDto), 200)]
    public IActionResult GetMensagemUserIdPadrao()
    {
        try
        {
            var mensagem = _larcClient.ObterMensagemParaUsuarioPadrao();
            return Ok(mensagem);
        }
        catch (Exception)
        {
            return StatusCode(500, "Falha ao estalecer conexão com o servidor.");
        }
    }

    [HttpGet("ObterUsuarioAplicacaoPadrao")]
    public IActionResult ObterUsuarioAplicacaoPadrao()
    {
        try
        {
            var usuarioAplicacaoPadrao = _larcClient.ObterUsuarioAplicacaoPadrao();
            return Ok(usuarioAplicacaoPadrao);
        }
        catch (Exception)
        {
            return StatusCode(500, "Falha ao estalecer conexão com o servidor.");
        }
    }
}