namespace Redes.TrocaMensagens.Comunicacao.Dtos;

public class MensagemRecebidaDto
{
    public string UserId { get; set; }
    public string Mensagem { get; set; }

    public MensagemRecebidaDto(string retorno)
    {
        var split = retorno.Split(':');
        UserId = split[0];
        Mensagem = new String(split[1].Where(x => x != (char)0).ToArray());
    }
}