using Common.Abstraction;
using System.Net;
using System.Net.Sockets;

namespace Common.Starters
{
    public class SockketClientStarter : ICommunicateStarter
    {
        public ISender Sender { get; set; }
        public IReceiver Receiver { get; set; }
        public Socket ClientSocket { get; set; }
        public IPEndPoint IpEndPoint { get; }

        public SockketClientStarter(ISender sender, IReceiver receiver, Socket clientSocket, IPEndPoint ipEndPoint)
        {
            Sender = sender;
            Receiver = receiver;
            ClientSocket = clientSocket;
            IpEndPoint = ipEndPoint;
        }

        public void Start(Action communicate)
        {
            throw new NotImplementedException();
        }
    }
}
