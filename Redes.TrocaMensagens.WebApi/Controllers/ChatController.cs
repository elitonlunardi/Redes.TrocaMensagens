using Microsoft.AspNetCore.Mvc;

namespace Redes.TrocaMensagens.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Front é foda <3");
    }
}