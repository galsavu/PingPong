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
    public class TcpServerStarter : ICommunicateStarter
    {
        private readonly CommunicatorsFactory _communicatorFactory;
        private readonly string _communicatorType;
        public ISender Sender { get; set; }
        public IReceiver Receiver { get; set; }
        public TcpListener Listener { get; set; }
        public IOutput Output { get; }
        public IInput Input { get; }

        public TcpServerStarter(ISender sender, IReceiver receiver, TcpListener listener, IOutput output, IInput input, CommunicatorsFactory communicatorFactory, string communicatorType)
        {
            Sender = sender;
            Receiver = receiver;
            Listener = listener;
            Output = output;
            Input = input;
            _communicatorFactory = communicatorFactory;
            _communicatorType = communicatorType;
        }

        public void Start()
        {
            Listener.Start();
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
            TcpClient clientSocket = Listener.AcceptTcpClient();
            Console.WriteLine("accepted client");
            var communicator = _communicatorFactory.CreateCommunicators(_communicatorType, this, Output, Input, clientSocket);
            await Task.Run(() => communicator.communicate());
        }


    }
}
