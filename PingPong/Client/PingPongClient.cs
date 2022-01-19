using Client.Abstraction;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public class PingPongClient : INetworkClient
    {
        public IPEndPoint ServerIpEndPoint { get; set; }
        public Socket ClientSocket { get; set; }

        public PingPongClient(IPAddress ipAddress, int port)
        {
            ServerIpEndPoint = new IPEndPoint(ipAddress, port);
            ClientSocket = new Socket(ServerIpEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartSocket()
        {
            ClientSocket.Connect(ServerIpEndPoint);
        }

        public async void Communicate()
        {
            throw new NotImplementedException();
        }
    }
}