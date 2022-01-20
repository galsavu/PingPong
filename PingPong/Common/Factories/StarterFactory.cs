using Common.Abstraction;
using Common.Starters;
using System.Net;
using System.Net.Sockets;

namespace Common.Factories
{
    public class StarterFactory
    {
        private readonly SenderFactory _senderFactory;
        private readonly ReceiverFactory _receiverFactory;

        public StarterFactory()
        {
            _senderFactory = new SenderFactory();
            _receiverFactory = new ReceiverFactory();
        }

        public ICommunicateStarter CreateStarter(string type, string ip, int port)
        {
            IPAddress iPAddress = IPAddress.Parse(ip);
            ISender sender = _senderFactory.CreateSender(type);
            IReceiver receiver = _receiverFactory.CreateReceiver(type);

            if (type == "socket server")
            {
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(iPAddress, port);

                return new SocketServerStarter(sender, receiver, listener, ipEndPoint);
            }

            else if (type == "socket client")
            {
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(iPAddress, port);
                return new SocketClientStarter(sender, receiver, listener, ipEndPoint);
            }

            return null;
        }
    }
}
