using Redes.TrocaMensagens.Comunicacao.Dtos;

namespace Redes.TrocaMensagens.Comunicacao.Interfaces;

public interface ILarcClient
{
    UsuariosDto ObterUsuarios();
    MensagemRecebidaDto ObterMensagemParaUsuarioPadrao();
    bool EnviarMensagem(EnvioMensagemDto mensagemDto);
}