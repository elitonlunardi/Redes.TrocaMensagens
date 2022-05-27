using Redes.TrocaMensagens.Comunicacao.Dtos;

namespace Redes.TrocaMensagens.Comunicacao.Interfaces;

public interface ILarcClient
{
    UsuariosDto ObterUsuarios();
    MensagensRecebidasDto ObterMensagens(string userId);
    bool EnviarMensagem(EnvioMensagemDto mensagemDto);
}