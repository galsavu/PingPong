using Common.Abstraction;
using System.Net;
using System.Net.Sockets;

namespace Common.Starters
{
    public class SocketClientStarter : ICommunicateStarter
    {
        public ISender Sender { get; set; }
        public IReceiver Receiver { get; set; }
        public Socket ClientSocket { get; set; }
        public IPEndPoint IpEndPoint { get; }

        public SocketClientStarter(ISender sender, IReceiver receiver, Socket clientSocket, IPEndPoint ipEndPoint)
        {
            Sender = sender;
            Receiver = receiver;
            ClientSocket = clientSocket;
            IpEndPoint = ipEndPoint;
        }

        public void Start(Action communicate)
        {
            try
            {
                ClientSocket.Connect(IpEndPoint);
                communicate?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
