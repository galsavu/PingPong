using Common.Abstraction;
using Common.Factories;
using System.Net;
using System.Net.Sockets;
using UI.Input.Abstraction;
using UI.Output.Abstraction;

namespace Common.Starters
{
    public class SocketClientStarter : ICommunicateStarter
    {
        private readonly ComunicatorsFactory _communicatorFactory;
        private readonly string _communicatorType;
        public ISender Sender { get; set; }
        public IReceiver Receiver { get; set; }
        public Socket ClientSocket { get; set; }
        public IPEndPoint IpEndPoint { get; }
        public IOutput Output { get; }
        public IInput Input { get; }

        public SocketClientStarter(ISender sender, IReceiver receiver, Socket clientSocket, IPEndPoint ipEndPoint, IOutput output, IInput input, ComunicatorsFactory communicatorFactory, string communicatorType)
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
                var communicator = _communicatorFactory.CreateComunicators(_communicatorType, this, Output, Input);
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
