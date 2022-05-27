using System.Net;
using System.Net.Sockets;
using System.Text;


var userIdPassWdAutenticacao = "6806:epftj";
var userIdComunicacao = "4038";
var userIdTodosUsuarios = "0";

int portaUdp = 1011;
int portaTcp = 1012;
var ipHostLarcInf = Dns.GetHostEntry("larc.inf.furb.br");
var ipAdress = ipHostLarcInf.AddressList[0].MapToIPv4();
IPEndPoint ipEndPointUdp = new IPEndPoint(ipAdress, portaUdp);
IPEndPoint ipEndPointTcp = new IPEndPoint(ipAdress, portaTcp);

var ipAddressLocal = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].MapToIPv4();
var ipEndpointLocal = new IPEndPoint(ipAddressLocal, 5900);

Task.Run(async () =>
{
    var socket = new Socket(ipEndpointLocal.AddressFamily, SocketType.Stream, protocolType: ProtocolType.Tcp);
    while (true)
    {
        // using ()
        socket.Connect(ipEndPointTcp);
        socket.Send(Encoding.UTF8.GetBytes($"GET USERS {userIdPassWdAutenticacao}"));

        var receive = new byte[128];
        var bytesEnviados = socket.Receive(receive);
        var receiveString = Encoding.UTF8.GetString(receive);
        Console.WriteLine(receiveString);
        await Task.Delay(TimeSpan.FromSeconds(6));
    }
});

using (var socket = new Socket(ipEndpointLocal.AddressFamily, SocketType.Stream, protocolType: ProtocolType.Tcp))
{
    socket.Connect(ipEndPointTcp);
    socket.Send(Encoding.UTF8.GetBytes($"GET MESSAGE {userIdPassWdAutenticacao}"));

    var receive = new byte[128];
    var bytesEnviados = socket.Receive(receive);
    var receiveString = Encoding.UTF8.GetString(receive);
}

using (var socket = new Socket(ipAddressLocal.AddressFamily, SocketType.Dgram, protocolType: ProtocolType.Udp))
{
    socket.Connect(ipEndPointUdp);

    var a = socket.Send(Encoding.UTF8.GetBytes($"SEND MESSAGE {userIdPassWdAutenticacao}:6806:Ola1 :D"));
}

Console.ReadLine();