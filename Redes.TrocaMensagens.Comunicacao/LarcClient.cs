using System.Net;
using System.Net.Sockets;
using System.Text;
using Redes.TrocaMensagens.Comunicacao.Dtos;
using Redes.TrocaMensagens.Comunicacao.Interfaces;

namespace Redes.TrocaMensagens.Comunicacao;

public class LarcClient : ILarcClient
{
    
    private const string _usuarioAplicacaoComSenha =  "6806:epftj";
    private const string TODOS_USUARIOS = "0";

    private readonly IPEndPoint _endpointLocal;
    private readonly IPEndPoint _endpointLarcTcp;
    private readonly IPEndPoint _endPointLarcUdp;
    private readonly UsuarioDto _usuarioAplicacaoComUsername;
    
    public LarcClient()
    {
        _usuarioAplicacaoComUsername = new UsuarioDto()
        {
             UserId = "6408",
             Username = "Éliton Lunardi"
        };
        int portaUdp = 1011;
        int portaTcp = 1012;
        var ipHostLarcInf = Dns.GetHostEntry("larc.inf.furb.br");
        var ipAdress = ipHostLarcInf.AddressList[0].MapToIPv4();

        var ipAddressLocal = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].MapToIPv4();
        _endpointLocal = new IPEndPoint(ipAddressLocal, 5900);
        _endpointLarcTcp = new IPEndPoint(ipAdress, portaTcp);
        _endPointLarcUdp = new IPEndPoint(ipAdress, portaUdp);
    }

    public UsuarioDto ObterUsuarioAplicacaoPadrao()
    {
        return _usuarioAplicacaoComUsername;
    }

    public UsuariosDto ObterUsuarios()
    {
        using (var socket = new Socket(_endpointLocal.AddressFamily, SocketType.Stream, protocolType: ProtocolType.Tcp))
        {
            socket.Connect(_endpointLarcTcp);
            socket.Send(Encoding.UTF8.GetBytes($"GET USERS {_usuarioAplicacaoComSenha}"));

            var receive = new byte[1024];
            socket.Receive(receive);

            var retorno = Encoding.UTF8.GetString(receive);

            return new UsuariosDto(retorno);
        }
    }

    public MensagemRecebidaDto ObterMensagemParaUsuarioPadrao()
    {
        using (var socket = new Socket(_endpointLocal.AddressFamily, SocketType.Stream, protocolType: ProtocolType.Tcp))
        {
            socket.Connect(_endpointLarcTcp);
            socket.Send(Encoding.UTF8.GetBytes($"GET MESSAGE {_usuarioAplicacaoComSenha}"));

            var receive = new byte[1024];
            socket.Receive(receive);

            var retorno = Encoding.UTF8.GetString(receive);

            return new MensagemRecebidaDto(retorno);
        }
    }

    public bool EnviarMensagem(EnvioMensagemDto mensagemDto)
    {
        using (var socket = new Socket(_endpointLocal.AddressFamily, SocketType.Dgram, protocolType: ProtocolType.Udp))
        {
            socket.Connect(_endPointLarcUdp);
            var payload = Encoding.UTF8.GetBytes($"SEND MESSAGE {_usuarioAplicacaoComSenha}:{mensagemDto.UserIdDestinatario}:{mensagemDto.Mensagem}");
            var bytesEnviados = socket.Send(payload);
            return bytesEnviados > 0;
        }
    }
}