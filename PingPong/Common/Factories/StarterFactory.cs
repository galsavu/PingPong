using Common.Abstraction;
using Common.Starters;
using System.Net;
using System.Net.Sockets;
using UI.Input.Abstraction;
using UI.Output.Abstraction;

namespace Common.Factories
{
    public class StarterFactory
    {
        private readonly SenderFactory _senderFactory;
        private readonly ReceiverFactory _receiverFactory;
        private readonly OutputFactory _outputFactory;
        private readonly InputFactory _inputFactory;

        public StarterFactory()
        {
            _senderFactory = new SenderFactory();
            _receiverFactory = new ReceiverFactory();
            _outputFactory = new OutputFactory();
            _inputFactory = new InputFactory();
        }

        public ICommunicateStarter CreateStarter(string type, string ip, int port, string outputType, string inputType, CommunicatorsFactory comunicatorsFactory)
        {
            IPAddress iPAddress = IPAddress.Parse(ip);
            ISender sender = _senderFactory.CreateSender(type);
            IReceiver receiver = _receiverFactory.CreateReceiver(type);
            IOutput output = _outputFactory.CreateOutput(outputType);
            IInput input = _inputFactory.CreateInput(inputType);
            IPEndPoint ipEndPoint = new IPEndPoint(iPAddress, port);
            if (type == "socket server")
            {
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                return new SocketServerStarter(sender, receiver, listener, ipEndPoint, output, input, comunicatorsFactory, type);
            }

            else if (type == "socket client")
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                return new SocketClientStarter(sender, receiver, socket, ipEndPoint, output, input, comunicatorsFactory, type);
            }

            else if(type == "tcp client")
            {
                TcpClient tcpClient = new TcpClient();
                return new TcpClientStarter(sender, receiver, tcpClient, ipEndPoint, output, input, comunicatorsFactory, type);
            }
            else if(type == "tcp listener")
            {
                TcpListener tcpListener = new TcpListener(iPAddress, port);
                return new TcpServerStarter(sender, receiver, tcpListener, output, input, comunicatorsFactory, type);
            }
            return null;
        }
    }
}
