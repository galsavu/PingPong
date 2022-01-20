using Common.Abstraction;
using Common.Factories;
using System.Net;
using System.Net.Sockets;
using UI.Input.Abstraction;
using UI.Output.Abstraction;

namespace Common.Starters
{
    public class TcpClientStarter : ICommunicateStarter
    {
        
        private readonly CommunicatorsFactory _communicatorFactory;
        private readonly string _communicatorType;
        public ISender Sender { get; set; }
        public IReceiver Receiver { get; set; }
        public TcpClient ClientSocket { get; set; }
        public IPEndPoint IpEndPoint { get; }
        public IOutput Output { get; }
        public IInput Input { get; }

        public TcpClientStarter(ISender sender, IReceiver receiver, TcpClient clientSocket, IPEndPoint ipEndPoint, IOutput output, IInput input, CommunicatorsFactory communicatorFactory, string communicatorType)
        {
            Sender = sender;
            Receiver = receiver;
            ClientSocket = clientSocket;
            IpEndPoint = ipEndPoint;
            Output = output;
            Input = input;
            _communicatorFactory = communicatorFactory;
            _communicatorType = communicatorType;
        }

        public void Start()
        {
            try
            {
                ClientSocket.Connect(IpEndPoint);
                Console.WriteLine($"connected to {IpEndPoint}");
                var communicator = _communicatorFactory.CreateCommunicators(_communicatorType, this, Output, Input, ClientSocket);
                communicator.communicate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
