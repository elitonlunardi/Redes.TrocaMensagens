namespace Redes.TrocaMensagens.Comunicacao.Dtos;

public class MensagensRecebidasDto
{
    private IEnumerable<MensagemRecebidaDto> MensagensRecebidasDtos { get; set; }

    public MensagensRecebidasDto(string retorno, string userId)
    {
        if (retorno == ":")
        {
            MensagensRecebidasDtos = new List<MensagemRecebidaDto>();
        }
        else
        {
            var mensagensString = retorno.Split('\n');

            var mensagens = mensagensString.Select(x =>
            {
                var dados = x.Split(':');

                return new MensagemRecebidaDto
                {
                    UserId = dados[0],
                    Mensagem = dados[1]
                };
            });

            MensagensRecebidasDtos = mensagens.Where(x => x.UserId == userId);
        }
    }
}