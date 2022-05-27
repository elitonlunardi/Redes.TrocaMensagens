using System.Net;
using System.Net.Sockets;
using System.Text;
using Redes.TrocaMensagens.Comunicacao.Dtos;
using Redes.TrocaMensagens.Comunicacao.Interfaces;

namespace Redes.TrocaMensagens.Comunicacao;

public class LarcClient : ILarcClient
{
    private static string USUARIO_APLICACAO = "6806:epftj";
    private static string USER_COMUNICACAO = "4038";
    private static string TODOS_USUARIOS = "0";
    
    private readonly IPEndPoint _endpointLocal;
    private readonly IPEndPoint _endpointLarc;
    private readonly IPEndPoint _endPointLarcUdp;
    
    public LarcClient()
    {
        int portaUdp = 1011;
        int portaTcp = 1012;
        var ipHostLarcInf = Dns.GetHostEntry("larc.inf.furb.br");
        var ipAdress = ipHostLarcInf.AddressList[0].MapToIPv4();
        
        var ipAddressLocal = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].MapToIPv4();
        _endpointLocal = new IPEndPoint(ipAddressLocal, 5900);
        _endpointLarc = new IPEndPoint(ipAdress, portaTcp);
        _endPointLarcUdp = new IPEndPoint(ipAdress, portaUdp);
    }
    
    public UsuariosDto ObterUsuarios()
    {
        var socket = new Socket(_endpointLocal.AddressFamily, SocketType.Stream, protocolType: ProtocolType.Tcp);
        
        socket.Connect(_endpointLarc);
        socket.Send(Encoding.UTF8.GetBytes($"GET USERS {USUARIO_APLICACAO}"));

        var receive = new byte[128];
        var bytesRecebidos = socket.Receive(receive);
        var retorno = Encoding.UTF8.GetString(receive);

        return new UsuariosDto(retorno);
    }

    public MensagensRecebidasDto ObterMensagens(string userId)
    {
        throw new NotImplementedException();
    }

    public bool EnviarMensagem(EnvioMensagemDto mensagemDto)
    {
        using (var socket = new Socket(_endpointLocal.AddressFamily, SocketType.Dgram, protocolType: ProtocolType.Udp))
        {
            socket.Connect(_endPointLarcUdp);
            var payload = Encoding.UTF8.GetBytes($"SEND MESSAGE {USUARIO_APLICACAO}:{mensagemDto.UserIdDestinatario}:{mensagemDto.Mensagem}");
            var bytesEnviados = socket.Send(payload);
            return bytesEnviados > 0;
        }
    }
}