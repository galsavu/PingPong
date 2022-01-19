using Server.Abstraction;
using Common.DTOS;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    public class PingPongServer : INetworkServer
    {
        public IPEndPoint ipEndPoint { get; set; }
        public Socket Listener { get; set; }

        public PingPongServer(IPAddress ipAddress, int port)
        {
            ipEndPoint = new IPEndPoint(ipAddress, port);
            Listener = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(ipEndPoint);
        }

        public void StartSocket()
        {     
            
        }

        public void Communicate()
        {
            throw new NotImplementedException();
        }
    }
}