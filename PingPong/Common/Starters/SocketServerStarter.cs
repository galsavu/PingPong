using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using System.Net;
using System.Net.Sockets;
using UI.Output.Abstraction;
using UI.Input.Abstraction;
using Common.Factories;
namespace Common.Starters
{
    public class SocketServerStarter : ICommunicateStarter
    {
        private readonly CommunicatorsFactory _communicatorFactory;
        private readonly string _communicatorType;
        public ISender Sender { get; set; }
        public IReceiver Receiver { get; set; }
        public Socket Listener { get; set; }
        public IPEndPoint IpEndPoint { get; }
        public IOutput Output { get; }
        public IInput Input { get; }

        public SocketServerStarter(ISender sender, IReceiver receiver, Socket listener, IPEndPoint ipEndPoint, IOutput output, IInput input, CommunicatorsFactory communicatorFactory, string communicatorType)
        {
            Sender = sender;
            Receiver = receiver;
            Listener = listener;
            IpEndPoint = ipEndPoint;
            Output = output;
            Input = input;
            _communicatorFactory = communicatorFactory;
            _communicatorType = communicatorType;
        }

        public void Start()
        {
            Listener.Bind(IpEndPoint);
            Listener.Listen();
            GetClientsConnections();   
           
        }

        public void GetClientsConnections()
        {
            while (true)
            {
                Task.Run(() => GetConnection());
            }
        }

        public async Task GetConnection()
        {
            Console.WriteLine("waiting for connection");
            Socket clientSocket = Listener.Accept();
            var communicator = _communicatorFactory.CreateCommunicators(_communicatorType, this, Output, Input, clientSocket);
            await Task.Run(() => communicator.communicate());
        }

        
    }
}
