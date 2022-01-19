using Server.Abstraction;
using Common.DTOS;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    public class PingPongServer : INetworkServer
    {
        private IPEndPoint _address;
        
        public PingPongServer(IPEndPoint address)
        {
            _address = address;
        }

        public void Communicate()
        {
            throw new NotImplementedException();
        }
    }
}